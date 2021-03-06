=============================================================================

	WINDOWS 应用程序       : CSReceiveWM_COPYDATA 项目概述
=============================================================================



/////////////////////////////////////////////////////////////////////////////

概要：
 
基于windows 消息 WM_COPYDATA 进程间通信(IPC) 是一种在本地机器上windows应用程序交换数据机制。

接受程序必须是一个windows应用程序。数据被传递必须不包含指针或者不能被应用程序接受的指向对象的引用。

当发送WM_COPYDATA消息时，引用数据不能被发送进程别的线程改变。 接受应用程序应该只考虑只读数据。

如果接受应用程序想要在SendMessage返回之后进入数据， 它必须拷贝数据到本地缓存。

这个代码例子示范了接受一个从应用程序（CSSendWM_COPYDATA）通过处理WM_COPYDATA.发送到客户数据结构（Mystruct）.



/////////////////////////////////////////////////////////////////////////////
演示:

下面的步骤贯穿整个WM_COPYDATA例子演示。

步骤1： 当你成功的在vs2008编译了CSSendWM_COPYDATA和CSReceiveWM_COPYDATA例子后，你将会得到
CSSendwM_COPYDATA.exe以及CSReceiveWM_COPYDATA.exe.

步骤2： 运行CSSendwM_COPYDATA.exe以及CSReceiveWM_COPYDATA.exe程序， 在CSSendwM_COPYDATA程序中
输入数字和消息
	数字： 123456
	消息： 你好，世界

点击发送按钮。 数字和消息将会被发送到CSReceiveWM_COPYDATA通过 WM_COPYDATA消息， 当CSReceiveWM_COPYDATA

收到消息后， 应用程序解压它们并且把它们显示在窗口上。



/////////////////////////////////////////////////////////////////////////////
与本例相关：
（当前例子和其他例子在微软 All-In-One Code Framework http://1code.codeplex.com）



CSSendWM_COPYDATA -> CSReceiveWM_COPYDATA
CSSendWM_COPYDATA 发送数据到 CSReceiveWM_COPYDATA 通过 WM_COPYDATA 
消息


/////////////////////////////////////////////////////////////////////////////
代码逻辑：

1. 在窗口形式中重写窗口过程

    protected override void WndProc(ref Message m)
    {
    }

2.  在窗口过程中处理WM_COPYDATA 消息
	
    if (m.Msg == WM_COPYDATA)
    {
    }
        
3.  从WM_COPYDATA消息lparam中获取COPYDATASTRUCT结构，从COPYDATASTRUCT.lpData取得数据(MyStruct object)


    // 从lParam参数获取COPYDATASTRUCT结构

    COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));

    // 如果大小匹配
    if (cds.cbData == Marshal.SizeOf(typeof(MyStruct)))
    {
        // 从非托管内存块中封送数据到MyStruct托管结构中
        MyStruct myStruct = (MyStruct)Marshal.PtrToStructure(cds.lpData, 
            typeof(MyStruct));
    }

4. 在窗口中显示数据


/////////////////////////////////////////////////////////////////////////////
参考文献：

WM_COPYDATA 消息
http://msdn.microsoft.com/en-us/library/ms649011.aspx


/////////////////////////////////////////////////////////////////////////////
