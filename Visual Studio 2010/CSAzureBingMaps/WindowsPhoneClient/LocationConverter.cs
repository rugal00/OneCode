﻿/********************************* 模块头 **********************************\
* 模块名:  LocationConverter.cs
* 项目名:  AzureBingMaps
* 版权 (c) Microsoft Corporation.
* 
* Silverlight转换器.
* 将Travel数据转为Bing Maps Location.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Device.Location;
using System.Windows.Data;
using AzureBingMaps.DAL;

namespace WindowsPhoneClient
{
    /// <summary>
    /// Silverlight转换器.
    /// 将Travel数据转为Bing Maps Location.
    /// </summary>
    public class LocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Travel)
            {
                Travel t = (Travel)value;
                return new GeoCoordinate(t.Latitude, t.Longitude);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
