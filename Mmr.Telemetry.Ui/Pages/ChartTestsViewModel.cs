using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmr.Telemetry.Ui.Pages
{
    internal class ChartTestsViewModel
    {
        public ISeries[] Series { get; } =
        {
            new LineSeries<double>
            {
                IsHoverable = false,
                GeometryFill = null,
                GeometryStroke = null,
                Fill = null,
                Values = Enumerable.Range(0, 70000).Select(x => Math.Sin(x / 200d)),
                Stroke = new SolidColorPaint(SKColors.Blue, 1f)
            }
        };
    }
}
