using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        public SortedPosList()
        {
            this.positions = new List<Position>();
        }

        public SortedPosList(string fileName)
        {
            this.positions = new List<Position>();
            filePath = Directory.GetCurrentDirectory() + "/" + fileName;
            if (File.Exists(filePath))
                Load();
            else

                CreateFile(filePath);
        }

        private List<Position> positions; 
        private string filePath;

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Count(); i++)
            {
                result += positions[i].ToString();
                if (i < Count() - 1)
                    result += ", ";
            }

            return result;
        }

        private string Encrypt()
        {
            string result = "";
            for (int i = 0; i < Count(); i++)
            {
                result += positions[i].X.ToString() + "/" + positions[i].Y.ToString();
                if (i < Count() - 1)
                    result += "|";
            }
            return result;
        }

        private void Decrypt(string data)
        {
            string[] posList = data.Split('|');
            foreach (string s in posList)
            {
                double x = Convert.ToDouble(s.Split('/')[0]);
                double y = Convert.ToDouble(s.Split('/')[1]);
                Add(new Position(x, y));
            }
        }

        private void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
        }

        private void Save()
        {
            string encrypted = Encrypt();
            System.IO.File.WriteAllText(filePath, encrypted);
        }

        private void Load()
        {
            string loadedText = System.IO.File.ReadAllText(filePath);
            Decrypt(loadedText);
        }

        public int Count()
        {
            return positions.Count;
        }

        public void Add(Position p)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (p < positions[i])
                {
                    positions.Insert(i, p);
                    return;
                }
            }
            positions.Add(p);
            if (filePath != null)
                Save();
        }

        public bool Remove(Position p)
        {
            bool removed = false;
            for (int i = 0; i < Count(); i++)
            {
                if (positions[i].Equals(p))
                {
                    positions.RemoveAt(i);
                    removed = true;
                }
            }
            if (removed && filePath != null)
                Save();
            return removed;
        }

        public SortedPosList Clone()
        {
            SortedPosList cloneList = new SortedPosList();
            foreach (Position p in positions)
            {
                Position posClone = p.Clone();
                cloneList.Add(posClone);
            }
            return cloneList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList withinCircleList = new SortedPosList();
            foreach (Position p in positions)
            {
                if (p % centerPos <= radius)
                    withinCircleList.Add(p);
            }
            return withinCircleList;
        }

        public static SortedPosList operator +(SortedPosList a, SortedPosList b)
        {
            SortedPosList result = new SortedPosList();
            foreach (Position p in a.positions)
                result.Add(p);
            foreach (Position p in b.positions)
                result.Add(p);
            return result;
        }

        public static SortedPosList operator *(SortedPosList a, SortedPosList b)
        {
            SortedPosList result = a.Clone();
            for (int i = 0; i < b.Count(); i++)
            {
                result.Remove(b[i]);
            }
            return result;
        }

        public Position this[int key]
        {
            get
            {
                return positions[key];
            }
        }
    }
}
