using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FGeo3D.GPS
{
    /// <summary>
    /// GPS串口通讯连接类
    /// </summary>
    public class Controller
    {
        private SerialPort serialPort;
        private string _comName;
        private byte[] _recvData;

        public bool IsComOpen => serialPort.IsOpen;

        /// <summary>
        /// 构造1：创建GPS串口控制器
        /// </summary>
        /// <param name="components"></param>
        public Controller(IContainer components)
        {
            _comName = GetComNum();
            serialPort = new SerialPort(components);
        }

        /// <summary>
        /// 构造2：
        /// </summary>
        public Controller()
        {
            _comName = GetComNum();
            serialPort = new SerialPort(_comName);
        }



        /// <summary>
        /// 打开串口，连接！
        /// </summary>
        /// <returns></returns>
        public bool OpenSerialPort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.PortName = _comName;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.ReadBufferSize = 32768;
            serialPort.WriteBufferSize = 32768;
            serialPort.BaudRate = 9600;
            try
            {
                serialPort.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 读取串口数据
        /// </summary>
        /// <returns>成功，则返回空字符串；失败，则返回完整接收数据。</returns>
        public string ReadData()
        {
            _recvData = new byte[80];
            string recv = "";
            var head = serialPort.ReadTo(",");
            if (head.StartsWith("$GPSTO") && serialPort.BytesToRead > 32)
            {
                serialPort.Read(_recvData, 0, 32);
            }
            else
            {
                recv = serialPort.ReadTo("\r\n");
            }
            return recv;
        }

        //获取X
        public double GetCoordX()
        {
            var degree = _recvData[0]/16*100 + _recvData[0]%16*10 + _recvData[1]/16;
            var minute = _recvData[1]%16*10 + _recvData[2]/16;
            var secondInt = _recvData[2]%16*10 + _recvData[3]/16;
            var secondDec = _recvData[3]%16;
            return double.Parse(degree * 3600 + minute * 60 + secondInt + "." + secondDec);
        }

        //获取Y
        public double GetCoordY()
        {
            var degree = _recvData[4]/16*100 + _recvData[4]%16*10 + _recvData[5]/16;
            var minute = _recvData[5]%16*10 + _recvData[6]/16;
            var secondInt = _recvData[6]%16*10 + _recvData[7]/16;
            var secondDec = _recvData[7]%16;
            return double.Parse(degree * 3600 + minute * 60 + secondInt + "." + secondDec);
        }

        //获取Z
        public double GetCoordZ()
        {
            return (_recvData[8]%16)*10000 + (_recvData[9]/16)*1000 + (_recvData[9]%16*100) +
                   (_recvData[10]/16*10) +  (_recvData[10]%16);
        }



        public bool CloseSerialPort(string comNum)
        {
            if (!serialPort.IsOpen)
            {
                return true;
            }
            try
            {
                serialPort.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        #region 获取串口

        /// <summary>
        /// 获取串口号
        /// </summary>
        /// <returns></returns>
        private string GetComNum()
        {
            int comNum = -1;
            string[] strArr = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
            foreach (string s in strArr)
            {
                if (s.Length >= 23 && s.Contains("CH340"))
                {
                    int start = s.IndexOf("(", StringComparison.Ordinal) + 3;
                    int end = s.IndexOf(")", StringComparison.Ordinal);
                    comNum = Convert.ToInt32(s.Substring(start + 1, end - start - 1));
                }
            }
            return string.Concat("COM" + comNum);
        }

        /// <summary>
        /// 获取系统设备信息.
        /// </summary>
        /// <param name="hardType">设备类型</param>
        /// <param name="propKey">关键字</param>
        /// <returns></returns>
        private string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
        {

            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null)
                        {
                            String str = hardInfo.Properties[propKey].Value.ToString();
                            strs.Add(str);
                        }

                    }
                }
                return strs.ToArray();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 枚举win32 api
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }

        #endregion
    }
}
