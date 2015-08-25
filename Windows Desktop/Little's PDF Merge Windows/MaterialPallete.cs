using System;
using System.Linq;
using System.Windows.Media;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    class MaterialPallete
    {
        //List of material design colors from https://www.materialpalette.com/.
        private System.Collections.Generic.List<Color> MaterialColors = new System.Collections.Generic.List<Color> { 
            (Color)ColorConverter.ConvertFromString("#f44336"),
            (Color)ColorConverter.ConvertFromString("#e91e63"),
            (Color)ColorConverter.ConvertFromString("#9c27b0"),
            (Color)ColorConverter.ConvertFromString("#673ab7"),
            (Color)ColorConverter.ConvertFromString("#3f51b5"),
            (Color)ColorConverter.ConvertFromString("#2196f3"),
            (Color)ColorConverter.ConvertFromString("#03a9f4"),
            (Color)ColorConverter.ConvertFromString("#00bcd4"),
            (Color)ColorConverter.ConvertFromString("#009688"),
            (Color)ColorConverter.ConvertFromString("#4caf50"),
            (Color)ColorConverter.ConvertFromString("#8bc34a"),
            (Color)ColorConverter.ConvertFromString("#cddc39"),
            (Color)ColorConverter.ConvertFromString("#ffeb3b"),
            (Color)ColorConverter.ConvertFromString("#ffc107"),
            (Color)ColorConverter.ConvertFromString("#ff9800"),
            (Color)ColorConverter.ConvertFromString("#ff5722"),
            (Color)ColorConverter.ConvertFromString("#795548"),
            (Color)ColorConverter.ConvertFromString("#9e9e9e"),
            (Color)ColorConverter.ConvertFromString("#607d8b")};

        public Color DarkPrimaryColor;
        public Color PrimaryColor;
        public Color LightPrimaryColor;
        public Color AccentColor;
        public MaterialPallete(Color color)
        {
            Color[] materialcolor = GetClosestColor(MaterialColors, color);
                DarkPrimaryColor = Color.FromRgb(56, 142, 60);
                PrimaryColor = Color.FromRgb(76, 175, 80);
                LightPrimaryColor = Color.FromRgb(200, 230, 201);
                AccentColor = Color.FromRgb(0, 150, 136);
        }

        /// <summary>
        /// Finds the closest color to a color.
        /// </summary>
        /// <param name="colorArray">The array to containing the colors to match to.</param>
        /// <param name="baseColor">The color to match to</param>
        /// <returns></returns>
        private static Color[] GetClosestColor(System.Collections.Generic.List<Color> colorArray, Color baseColor)
        {
            var colors = colorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) });
            var min = colors.Min(x => x.Diff);
            int index = colorArray.FindIndex(i => i == colors.AsParallel().ToList().Find(x => x.Diff == min).Value);
            try
            {
                return new Color[2] { colors.AsParallel().ToList().Find(x => x.Diff == min).Value, colorArray.ElementAt(index - 1) };
            }
            catch
            {
                return new Color[2] { colors.AsParallel().ToList().Find(x => x.Diff == min).Value, colorArray.ElementAt(index) };
            }
        }

        private static int GetDiff(Color color, Color baseColor)
        {
            int a = color.A - baseColor.A,
                r = color.R - baseColor.R,
                g = color.G - baseColor.G,
                b = color.B - baseColor.B;
            return a * a + r * r + g * g + b * b;
        }
    }
}
