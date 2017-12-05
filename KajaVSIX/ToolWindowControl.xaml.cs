using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace KajaVSIX
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ToolWindowControl.
    /// </summary>
    public partial class ToolWindowControl : UserControl
    {
        public DateTime MeetDate { get; } = new DateTime(2017, 10, 31, 9, 50, 20);
        public DateTime CoupleDate { get; } = new DateTime(2017, 11, 12);

        public static Timer MainTimer { get; } = new Timer(1000);

        private readonly List<char> _postsrcipts = new List<char>() { '2', '3', '4' };

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowControl"/> class.
        /// </summary>
        public ToolWindowControl()
        {
            this.InitializeComponent();
            MainTimer.Start();
            MainTimer.Elapsed += (o, e) =>
            {
                var meetupSpan = DateTime.Now - MeetDate;
                var coupleSpan = DateTime.Now - CoupleDate;

                this.Dispatcher.Invoke(() =>
                {
                    var meetupHours = _postsrcipts.Contains(meetupSpan.Hours.ToString().Last())
                        ? "godziny"
                        : "godzin";
                    var meetupSeconds = _postsrcipts.Contains(meetupSpan.Seconds.ToString().Last())
                        ? "sekundy"
                        : "sekund";
                    var coupleHours = _postsrcipts.Contains(coupleSpan.Hours.ToString().Last())
                        ? "godziny"
                        : "godzin";
                    var coupleSeconds = _postsrcipts.Contains(coupleSpan.Seconds.ToString().Last())
                        ? "sekundy"
                        : "sekund";

                    timer1Label.Content = $"{meetupSpan.Days} dni {meetupSpan.Hours.ToString().PadLeft(2, '0')} {meetupHours} {meetupSpan.Seconds.ToString().PadLeft(2, '0')} {meetupSeconds}";
                    timer2Label.Content = $"{coupleSpan.Days} dni {coupleSpan.Hours.ToString().PadLeft(2, '0')} {coupleHours} {coupleSpan.Seconds.ToString().PadLeft(2, '0')} {coupleSeconds}";
                });
            };
        }
    }
}