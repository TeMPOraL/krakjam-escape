using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;

namespace UglyFramework.Anim
{
    /// <summary>
    /// Klasa przechowuje info o pojedynczej animacji np. chodu
    /// </summary>
    public class AnimationSet
    {
        /// <summary>
        /// numer pierwszej klatki animacji
        /// </summary>
        public int FrameStartNumber
        {
            get;
            set;
        }
        
        /// <summary>
        /// ilosc klatek przypadajacych na animacje
        /// </summary>
        public int FrameCount
        {
            get;
            set;
        }

        public static AnimationSet Deserialize(string filename)
        {
            AnimationSet animSet;
            XmlSerializer serializer = new XmlSerializer(typeof(AnimationSet));
            Stream stream = File.Open(filename, FileMode.Open);
            animSet = (AnimationSet)serializer.Deserialize(stream);
            stream.Close();
            return animSet;
        }

        public void Serialize(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AnimationSet));
            Stream stream = File.Open(filename, FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Close();
        }

    }
}
