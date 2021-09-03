using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontManager : ManagerBase
    {
        private static Font NodeToCompare = new Font();
        private static FontManager Instance = null;
        private static FontManager ActiveFontManager = null;

        public FontManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)   
        {
            // initialize derived data here
            FontManager.ActiveFontManager = null;
        }

        public static void Create()
        {
            // make sure values are ressonable 
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                Instance = new FontManager();
            }
        }
        public static void Destroy()
        {
        }

        public static Font Add(Font.Name name, SpriteBatch.Name SB_Name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontManager manager = FontManager.ActiveFontManager;

            Font node = (Font)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch sprite_batch = SpriteBatchManager.Find(SB_Name);
            Debug.Assert(sprite_batch != null);
            Debug.Assert(node.SpriteFont != null);
            sprite_batch.Attach(node.SpriteFont);

            return node;
        }
        public static void SetActive(FontManager font_manager)
        {
            FontManager manager = FontManager.GetInstance();
            Debug.Assert(manager != null);

            Debug.Assert(font_manager != null);
            FontManager.ActiveFontManager = font_manager;
        }

        public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
        {
            GlyphManager.AddXml(glyphName, assetName, textName);
        }

        public static Font Find(Font.Name name)
        {
            FontManager manager = FontManager.ActiveFontManager;

            FontManager.NodeToCompare.name = name;

            Font data = (Font)manager.baseFind(FontManager.NodeToCompare);
            return data;
        }

        public static void Remove(Font current_node)
        {
            Debug.Assert(current_node != null);

            FontManager manager = FontManager.ActiveFontManager;
            // Remove it from the manager
            SpriteNode SpriteNode = current_node.SpriteFont.GetSpriteNode();
            Debug.Assert(SpriteNode != null);
            SpriteBatchManager.Remove(SpriteNode);

            manager.baseRemoveNode(current_node);
        }
        public static void Dump()
        {
            FontManager manager = FontManager.GetInstance();
            manager.baseDumpNodes();
        }

        private static FontManager GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(Instance != null);

            return Instance;
        }

        override protected NodeBase derivedCreateNode()
        {
            NodeBase node_base = new Font();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
