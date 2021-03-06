﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using RetroFun.Subscribers;

namespace RetroFun.Pages
{
    [ToolboxItem(true)]
    [DesignerCategory("UserControl")]
    public partial class AvatarEditorPg : ObservablePage
    {
        private const string FIGURE_DATA_PATH = "Bobba_look.xml";

        private IDictionary<int, List<PartColor>> _palettes;
        private IList<PartSet> _partSets;

        public AvatarEditorPg()
        {
            InitializeComponent();

            //InitFiguredata(FIGURE_DATA_PATH);
        }

        private void InitFiguredata(string path)
        {
            _palettes = new Dictionary<int, List<PartColor>>();
            _partSets = new List<PartSet>();

            int currentPaletteId = -1;
            var partColors = new List<PartColor>(64);

            using (var fs = File.OpenRead(path))
            using (var tr = new StreamReader(fs))
            {
                var doc = XDocument.Load(tr);

                var colors = doc.Elements("color").ToList();
            }
        }
    }

    public class PartColor
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public bool Club { get; set; }
        public bool Selectable { get; set; }
        public Color Color { get; set; }

        public PartColor()
        { }

        public PartColor(int id, int index, bool club, bool selectable, Color color)
        {
            Id = id;
            Index = index;
            Club = club;
            Selectable = selectable;
            Color = color;
        }
    }
    public class PartSet
    {
        public string Type { get; set; }
        public int PaletteId { get; set; }
        public bool MAndMZero { get; set; }
        public bool MAndFZero { get; set; }
        public bool MAndMOne { get; set; }
        public bool MAndFOne { get; set; }

        public IList<Set> Sets { get; set; }
    }
    public class Set
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public bool Club { get; set; }
        public bool Colorable { get; set; }
        public bool Selectable { get; set; }

        public IList<Part> Parts { get; set; }
    }
    public class Part
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Colorable { get; set; }
        public int Index { get; set; }
        public int ColorIndex { get; set; }
    }


}
