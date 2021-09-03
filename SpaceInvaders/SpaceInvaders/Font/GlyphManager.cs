using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GlyphManager : ManagerBase
    {
        // Data
        private readonly Glyph NodeToCompare;
        private static GlyphManager Instance = null;

        // Constructor
        private GlyphManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)   
        {
            // initialize derived data here
            this.NodeToCompare = new Glyph();
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                Instance = new GlyphManager(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
        }

        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphManager manager = GlyphManager.GetInstance();

            Glyph node = (Glyph)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(name, key, textName, x, y, width, height);
            return node;
        }
        public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
        {
            // STN - only used to load the XML once invoked in the game load content
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {

                            GlyphManager.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphManager manager = GlyphManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeToCompare.name = name;
            manager.NodeToCompare.key = key;

            Glyph data = (Glyph)manager.baseFind(manager.NodeToCompare);
            return data;
        }

        public static void Remove(Glyph image)
        {
            Debug.Assert(image != null);

            GlyphManager manager = GlyphManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseRemoveNode(image);
        }
        public static void Dump()
        {
            GlyphManager manager = GlyphManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        private static GlyphManager GetInstance()
        {
            Debug.Assert(Instance != null);

            return Instance;
        }
        
        override protected NodeBase derivedCreateNode()
        {
            NodeBase node_base = new Glyph();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
