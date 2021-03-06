﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PlaystationApp.Core.Entity;

namespace PlaystationApp.Tools
{
    public class ValuePercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as TrophyEntity.TrophyTitle;
            if (item == null) return string.Empty;
            if (item.ComparedUser != null)
            {
                return string.Format("{0}%", item.ComparedUser.Progress );
            }
            if (item.FromUser != null)
            {
                return string.Format("{0}%", item.FromUser.Progress);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
