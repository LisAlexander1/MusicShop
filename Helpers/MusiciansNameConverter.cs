using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using MusicShop.Models;

namespace MusicShop.Helpers;

public class MusiciansNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is List<EnsembleMembership> ensembles)
        {
            if (ensembles.Count > 3)
            {
                return string.Join(", ", ensembles.Select(e => $"{e.Musician.LastName} {e.Musician.FirstName} {e.Musician.Surname}" ).Take(3)) + "...";
            }
            return string.Join(", ", ensembles.Select(e=> $"{e.Musician.LastName} {e.Musician.FirstName} {e.Musician.Surname}"));
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}