﻿/****************************** 模块头 *************************************\
* Module Name:	IRestService.cs
* Project:		CSAzureServiceBusSLRest
* Copyright (c) Microsoft Corporation.
* 
* 该文件是WCF REST Service的服务契约.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AzureServiceBusSLRest
{
	[ServiceContract]
	public interface IRestService
	{
		/// <summary>
		/// 用法: https://namespace.servicebus.windows.net/file/filename
		/// </summary>
		[OperationContract, WebGet(UriTemplate = "/file/{fileName}")]
		Stream DownloadFile(string fileName);

		/// <summary>
		/// 用法: https://namespace.servicebus.windows.net/file/filename
        /// 注意这是一个POST操作，不能被浏览器调用.
		/// </summary>
		[OperationContract, WebInvoke(UriTemplate = "/file/{fileName}", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
		string UploadFile(string fileName, Stream content);

		/// <summary>
		/// 用法: https://namespace.servicebus.windows.net/clientaccesspolicy.xml
		/// </summary>
		[OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
		Stream GetClientAccessPolicy();
	}
}
