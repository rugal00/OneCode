﻿'/********************************* 模块头 **********************************\
'* 模块名:  LocationConverter.vb
'* 项目名:  AzureBingMaps
'* 版权 (c) Microsoft Corporation.
'* 
'* Silverlight转换器.
'* 将Travel数据转为Bing Maps Location.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports System.Device.Location
Imports System.Windows.Data
Imports WindowsPhoneClient.AzureBingMaps.DAL

''' <summary>
''' Silverlight转换器.
''' 将Travel数据转为Bing Maps Location.
''' </summary>
Public Class LocationConverter
    Implements IValueConverter
    Public Function Convert( _
                           ByVal value As Object, _
                           ByVal targetType As Type, _
                           ByVal parameter As Object, _
                           ByVal culture As System.Globalization.CultureInfo _
                           ) As Object Implements IValueConverter.Convert
        If TypeOf value Is Travel Then
            Dim t As Travel = DirectCast(value, Travel)
            Return New GeoCoordinate(t.Latitude, t.Longitude)
        End If
        Return Nothing
    End Function

    Public Function ConvertBack( _
                               ByVal value As Object, _
                               ByVal targetType As Type, _
                               ByVal parameter As Object, _
                               ByVal culture As System.Globalization.CultureInfo _
                               ) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class