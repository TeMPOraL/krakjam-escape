using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;

namespace KrakGame
{
    //FIXME where to put "next level" info?

    [Serializable]
    public class MapObjectData
    {
        public string id;   //id - optional
        public string type; //type - the general class of objects
        public bool collideWithPlayer;  //default collision mode
        public string state;    //additional state data
    }

    [Serializable]
    public class MapTerrainElement : MapObjectData
    {
        public string terrainDetailType;   //detailed type of terrain element - ie. which texture set

        public List<Vector2> arbitraryGeom;    //arbitrary geometry

        public MapTerrainElement()
        {
            arbitraryGeom = new List<Vector2>();
        }
    }

    [Serializable]
    public class MapLayer
    {
        public string layerName;

        public float parallaxDistance;  //TODO range?

        public List<MapTerrainElement> layerTerrain;
        public List<MapObjectData> layerObjects;

        public MapLayer()
        {
            layerTerrain = new List<MapTerrainElement>();
            layerObjects = new List<MapObjectData>();
        }
    }

    [Serializable]
    public class MapData
    {
        public string mapName;
        public string backgroundName;

        public List<MapLayer> layers;

        public MapData()
        {
            layers = new List<MapLayer>();
        }

        public static MapData DeserializeMap(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open);

            XmlSerializer serializer = new XmlSerializer(typeof(MapData));
            MapData map = (MapData)serializer.Deserialize(stream);

            stream.Close();

            return map;
        }

        public static void SerializeMap(MapData map, string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Create);

            XmlSerializer serializer = new XmlSerializer(typeof(MapData));
            serializer.Serialize(stream, map);

            stream.Close();
        }
    }

}
