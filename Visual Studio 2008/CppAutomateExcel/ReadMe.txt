========================================================================
    控制台应用程序 : CppAutomateExcel 项目概述
========================================================================

/////////////////////////////////////////////////////////////////////////////
摘要:

CppAutomateExcel案例阐述了通过VC++代码生成Microsoft Excel实例、填充数据
到指定区域、创建，保存工作簿以及关闭Excel应用程序并释放非托管COM资源的相关过程。

可以通过下面三种基本方式构建VC++自动化代码：

1. 通过使用#import指令和智能指针自动化Excel (Solution1.h/cpp)

Solution1.h及Solution1.cpp文件中的代码阐述了如何使用#import指令自动化Excel的方法。
#import(http://msdn.microsoft.com/en-us/library/8etzzkb6.aspx)
作为伴随VC++5.0出现的一种新的指令，能够通过指定类型库生成VC++“智能指针”。
虽然这种方式功能强大，但并不推荐使用，因为将其用于Microsoft Office应用程序时，
往往将导致引用计数问题。与Solution2.h及Solution2.cpp中的直接API方法不同，
智能指针使我们能够受益于类型信息，从而对对象进行早期/后期绑定。#import指令
添加无序的Guid到项目，而COM API则被封装到由#import 指令生成的自定义类中。


2. 通过使用C++和COM API 自动化Excel (Solution2.h/cpp)

Solution2.h 和Solution2.cpp文件中的代码阐述了使用C/C++及COM API自动化Excel的过程。
这种原始的自动化方式虽然实现起来更加困难，但有时通过它能够有效避免利用MFC方式或#import指令时
所产生的开销及问题。基本上，较为常用的有API中的CoCreateInstance()及 COM中的IDispatch和IUnknown。

3. 利用MFC方式自动化Excel(该案例不涉及利用MFC 自动化Excel)

通过MFC，Visual C++类向导能自动从类库中生成“包装类”。这些类简化了COM服务器的使用。该示例不涉及用MFC
的方式自动化Excel。

/////////////////////////////////////////////////////////////////////////////
先决条件:

必须在装有Microsoft Excel2007的计算机上运行该代码案例。


/////////////////////////////////////////////////////////////////////////////
演示:
下面的步骤阐述了Excel自动化样例的运行流程，即启动一个Excel 实例，生成工作簿，填充数据到指定区域，
保存工作簿并最终彻底退出Excel程序。

步骤1.  在Visual Studio2008中成功建立示例项目后，将获得名为CppAutomateExcel.exe.的应用程序。

步骤2. 打开Windows任务管理器（通过Ctrl+Shift+Esc）并确认没有正在执行的Excel程序。

步骤3. 运行程序。若无异常抛出，将在控制台窗口中打印如下内容。

  Excel.Application is started                              // Excel.Application已启动
  A new workbook is created                                 // 新的工作簿已创建
  The active worksheet is renamed as Report                 // 处于活动状态的工作表被重命名为Report
  Filling data into the worksheet ...                       // 填充数据到工作表
  Save and close the workbook                               // 保存并关闭工作簿
  Quit the Excel application                                // 退出Excel应用程序

   Excel.Application is started                             // Excel.Application已启动
  A new workbook is created                                 // 新的工作簿已创建
  The active worksheet is renamed as Report                 // 处于活动状态的工作表被重命名为Report
  Filling data into the worksheet ...                       // 填充数据到工作表
  Save and close the workbook                               // 保存并关闭工作簿
  Quit the Excel application                                // 退出Excel应用程序


至此，在应用程序的目录中，你将看见两个分别名为Sample.xlsx和Sample2.xlsx的工作簿。
每个工作簿都各自包含一个名为”Report”的工作表。工作表内区域A2：B6间的数据如下。

  John         Smith
  Tom          Brown
  Sue          Thomas
  Jane         Jones
  Adam         Johnson

步骤4. 在Windows任务管理器中，确认Excel.exe进程不存在。例如，Excel实例已被正常关闭或移除。


/////////////////////////////////////////////////////////////////////////////
相关示例:

CppAutomateExcel - CSAutomateExcel - VBAutomateExcel

这些示例采用不同的编程语言自动化Excel并完成相同的任务。



/////////////////////////////////////////////////////////////////////////////
创建过程:

A. 使用#import指令和智能指针自动化Excel(Solution1.h/cpp)

步骤1. 使用#import指令引入目标COM服务器类库
	#import "libid:2DF8D04C-5BFA-101B-BDE5-00AA0044DE52" \
		rename("RGB", "MSORGB")
		rename("DocumentProperties", "MSODocumentProperties")
	// [-或者-]
	//#import "C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE12\\MSO.DLL" \
	//	rename("RGB", "MSORGB")
	//	rename("DocumentProperties", "MSODocumentProperties")

	using namespace Office;

	#import "libid:0002E157-0000-0000-C000-000000000046"
	// [-或者-]
	//#import "C:\\Program Files\\Common Files\\Microsoft Shared\\VBA\\VBA6\\VBE6EXT.OLB"

	using namespace VBIDE;

	#import "libid:00020813-0000-0000-C000-000000000046" \
		rename("DialogBox", "ExcelDialogBox") \
		rename("RGB", "ExcelRGB") \
		rename("CopyFile", "ExcelCopyFile") \
		rename("ReplaceText", "ExcelReplaceText") \
		no_auto_exclude
	// [-或者-]
	//#import "C:\\Program Files\\Microsoft Office\\Office12\\EXCEL.EXE" \
	//	rename("DialogBox", "ExcelDialogBox") \
	//	rename("RGB", "ExcelRGB") \
	//	rename("CopyFile", "ExcelCopyFile") \
	//	rename("ReplaceText", "ExcelReplaceText") \
	//	no_auto_exclude

步骤2. 构建项目。如果构建成功，编译器将生成后缀名分别为.tlh和.tli的文件，该文件封装了基于#import指令自定义
类型库的COM服务器。作为包装类，我们可以使用它来创建COM类并访问相关属性，方法等。

步骤3. 在当前线程上初始化COM类库并通过调用CoInitializeEx或CoInitialize方法确认并发模型为单线程单元(STA)。


步骤4. 使用智能指针创建Excel.Application COM对象。类名为原接口名（如：Excel::_Application）加上”Ptr“后缀。
我们可以使用智能指针类的构造函数或是CreateInstance方法创建COM对象。

步骤5. 通过智能指针自动化Excel COM对象。在该示例中，Excel自动化基本操作如下：

	Create a new Workbook. (i.e. Application.Workbooks.Add)    // 创建一个新的工作簿(如：Application.Workbooks.Add)
	Get the active Worksheet, and rename it to be "Report".    // 获取处于活动状态的工作表，并将其重命名为“Report”
	Fill data into the worksheet's cells.                      // 填充数据到工作表单元
	Save the workbook as a xlsx file and close it.             // 将工作簿保存为xlsx文件并关闭


步骤6. 退出Excel应用程序（如： Application.Quit()）


步骤7. 由于智能指针将自动释放，因此无需手动释放COM对象。


步骤8. 如果被引入的类型库不是raw_interfaces_only并且没有使用原始接口(如：raw_Quit)，
则必须对COM异常进行捕获。例如：

	#import "XXXX.tlb"
	try
	{
		spXlApp->Quit();
	}
	catch (_com_error &err)
	{
	}


步骤9. 调用CoUninitialize为该线程撤销COM
-----------------------------------------------------------------------------

B. 通过C++和COM API自动化Excel(Solution2.h/cpp)

步骤1. 添加自动化辅助功能函数，AutoWrap。


步骤2.  在当前线程上初始化COM类库并通过调用CoInitializeEx或CoInitialize方法确认并发模型为单线程单元(STA)。


步骤3. 使用API CLSIDFromProgID获取Excel COM服务器的CLSID。

步骤4. 启动Excel COM服务器并通过API CoCreateInstance获取IDispatch接口。

步骤5. 通过AutoWrap自动化Excel COM对象。在该示例中，Excel自动化基本操作如下：

	Create a new Workbook. (i.e. Application.Workbooks.Add)    // 创建一个新的工作簿(如：Application.Workbooks.Add)
	Get the active Worksheet, and rename it to be "Report".    // 获取处于活动状态的工作表，并将其重命名为“Report”
	Fill data into the worksheet's cells.                      // 填充数据到工作表单元
	Save the workbook as a xlsx file and close it.             // 将工作簿保存为xlsx文件并关闭

步骤6. 退出Excel应用程序（如：Application.Quit()）。

步骤7. 释放COM对象。

步骤8. 调用CoUninitialize为该线程撤销COM

/////////////////////////////////////////////////////////////////////////////
参考资料:

MSDN: Excel 2007 Developer Reference
http://msdn.microsoft.com/en-us/library/bb149067.aspx

Office Automation Using Visual C++
http://support.microsoft.com/kb/196776/

How to automate Excel from C++ without using MFC or #import
http://support.microsoft.com/kb/216686


/////////////////////////////////////////////////////////////////////////////