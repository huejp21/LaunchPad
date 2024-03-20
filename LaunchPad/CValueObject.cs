using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace LaunchPad
{
  public enum KeyBoard
  {
    Key_ESC = 0,
    Key_F1,
    Key_F2,
    Key_F3,
    Key_F4,
    Key_F5,
    Key_F6,
    Key_F7,
    Key_F8,
    Key_F9,
    Key_F10,
    Key_F11,
    Key_F12,
    Key_PrintScreen,
    Key_ScrollLock,
    Key_PauseBreak,
    Key_Tilde,
    Key_1,
    Key_2,
    Key_3,
    Key_4,
    Key_5,
    Key_6,
    Key_7,
    Key_8,
    Key_9,
    Key_0,
    Key_Hyphen,
    Key_Plus,
    Key_BackSpace,
    Key_Tap,
    Key_Q,
    Key_W,
    Key_E,
    Key_R,
    Key_T,
    Key_Y,
    Key_U,
    Key_I,
    Key_O,
    Key_P,
    Key_LSquareBracket,
    Key_RSquareBracket,
    Key_BackSlash,
    Key_CapsLock,
    Key_A,
    Key_S,
    Key_D,
    Key_F,
    Key_G,
    Key_H,
    Key_J,
    Key_K,
    Key_L,
    Key_Semicolon,
    Key_Apostrophe,
    Key_Enter,
    Key_LShift,
    Key_Z,
    Key_X,
    Key_C,
    Key_V,
    Key_B,
    Key_N,
    Key_M,
    Key_Comma,
    Key_Period,
    Key_Slash,
    Key_RShift,
    Key_LCtrl,
    Key_LWin,
    Key_LAlt,
    Key_SpaceBar,
    Key_RAlt,
    Key_FN,
    Key_RCtrl,
    Key_Insert,
    Key_Home,
    Key_PageUp,
    Key_Delete,
    Key_End,
    Key_PageDown,
    Key_UpArrow,
    Key_LeftArrow,
    Key_DownArrow,
    Key_RightArrow,
    Key_NumberLock,
    Key_NumSlash,
    Key_NumAsterisk,
    Key_NumHyphen,
    Key_Num7,
    Key_Num8,
    Key_Num9,
    Key_NumPlus,
    Key_Num4,
    Key_Num5,
    Key_Num6,
    Key_Num1,
    Key_Num2,
    Key_Num3,
    Key_NumEnter,
    Key_Num0,
    Key_NumPeriod,
    Key_MAX
  };

  class CValueObject
  {
    static public int g_nThreadMax = 16;
    static public System.Windows.Forms.Button[] g_arrButton = new System.Windows.Forms.Button[CValueObject.g_nThreadMax];
    static public string g_SettingFileDirectory;
    static public System.Drawing.Color[] g_colorButton = new System.Drawing.Color[g_nThreadMax];
    static public string[] g_SoundFileDirectory = new string[g_nThreadMax];
    static public int[] g_KeySetting = new int[g_nThreadMax];
    static public string[] g_ButtonName = new string[g_nThreadMax];
    //KeyStatus Down = 1, Up = 0;
    static public int[] g_KeyStatus = new int[(int)KeyBoard.Key_MAX];

    static public bool CreateXML(string strFileFullPath)
    {
      try
      {
        XmlTextWriter textWriter = new XmlTextWriter(strFileFullPath, Encoding.UTF8);
        textWriter.Formatting = Formatting.Indented;

        textWriter.WriteStartDocument();
        textWriter.WriteStartElement("root");

        textWriter.WriteStartElement("DefaultDirectory");
        textWriter.WriteString(g_SettingFileDirectory);
        textWriter.WriteEndElement();

        textWriter.WriteStartElement("ThreadCount");
        textWriter.WriteString(string.Format("{0}", g_nThreadMax));
        textWriter.WriteEndElement();

        for (int i = 0; i < g_SoundFileDirectory.Length; i++)
        {
          textWriter.WriteStartElement(string.Format("SoundFileDirectory{0}", i));
          textWriter.WriteString(g_SoundFileDirectory[i]);
          textWriter.WriteEndElement();
        }

        for (int i = 0; i < g_KeySetting.Length; i++)
        {
          textWriter.WriteStartElement(string.Format("KeySetting{0}", i));
          textWriter.WriteString(string.Format("{0}", g_KeySetting[i]));
          textWriter.WriteEndElement();
        }

        for (int i = 0; i < g_ButtonName.Length; i++)
        {
          textWriter.WriteStartElement(string.Format("ButtonName{0}", i));
          textWriter.WriteString(string.Format("{0}", g_ButtonName[i]));
          textWriter.WriteEndElement();
        }

        for (int i = 0; i < g_colorButton.Length; i++)
        {
          textWriter.WriteStartElement(string.Format("colorButton{0}", i));
          textWriter.WriteString(string.Format("{0},{1},{2}", g_colorButton[i].R, g_colorButton[i].G, g_colorButton[i].B));
          textWriter.WriteEndElement();
        }

        textWriter.WriteEndElement();
        textWriter.WriteEndDocument();
        textWriter.Close();
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    static public bool LoadXML(string strFileFullPath)
    {
      try
      {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(strFileFullPath);
        XmlElement root = xmldoc.DocumentElement;
        // 노드 요소들
        XmlNodeList nodes = root.ChildNodes;
        // 노드 요소의 값을 읽어 옵니다.

        string[] strResult;
        foreach (XmlNode node in nodes)
        {
          switch (node.Name)
          {
            case "DefaultDirectory": g_SettingFileDirectory = node.InnerText; break;
            case "ThreadCount": g_nThreadMax = Int32.Parse(node.InnerText); break;

            case "SoundFileDirectory0": g_SoundFileDirectory[0] = node.InnerText; break;
            case "SoundFileDirectory1": g_SoundFileDirectory[1] = node.InnerText; break;
            case "SoundFileDirectory2": g_SoundFileDirectory[2] = node.InnerText; break;
            case "SoundFileDirectory3": g_SoundFileDirectory[3] = node.InnerText; break;
            case "SoundFileDirectory4": g_SoundFileDirectory[4] = node.InnerText; break;
            case "SoundFileDirectory5": g_SoundFileDirectory[5] = node.InnerText; break;
            case "SoundFileDirectory6": g_SoundFileDirectory[6] = node.InnerText; break;
            case "SoundFileDirectory7": g_SoundFileDirectory[7] = node.InnerText; break;
            case "SoundFileDirectory8": g_SoundFileDirectory[8] = node.InnerText; break;
            case "SoundFileDirectory9": g_SoundFileDirectory[9] = node.InnerText; break;
            case "SoundFileDirectory10": g_SoundFileDirectory[10] = node.InnerText; break;
            case "SoundFileDirectory11": g_SoundFileDirectory[11] = node.InnerText; break;
            case "SoundFileDirectory12": g_SoundFileDirectory[12] = node.InnerText; break;
            case "SoundFileDirectory13": g_SoundFileDirectory[13] = node.InnerText; break;
            case "SoundFileDirectory14": g_SoundFileDirectory[14] = node.InnerText; break;
            case "SoundFileDirectory15": g_SoundFileDirectory[15] = node.InnerText; break;

            case "KeySetting0": g_KeySetting[0] = Int32.Parse(node.InnerText); break;
            case "KeySetting1": g_KeySetting[1] = Int32.Parse(node.InnerText); break;
            case "KeySetting2": g_KeySetting[2] = Int32.Parse(node.InnerText); break;
            case "KeySetting3": g_KeySetting[3] = Int32.Parse(node.InnerText); break;
            case "KeySetting4": g_KeySetting[4] = Int32.Parse(node.InnerText); break;
            case "KeySetting5": g_KeySetting[5] = Int32.Parse(node.InnerText); break;
            case "KeySetting6": g_KeySetting[6] = Int32.Parse(node.InnerText); break;
            case "KeySetting7": g_KeySetting[7] = Int32.Parse(node.InnerText); break;
            case "KeySetting8": g_KeySetting[8] = Int32.Parse(node.InnerText); break;
            case "KeySetting9": g_KeySetting[9] = Int32.Parse(node.InnerText); break;
            case "KeySetting10": g_KeySetting[10] = Int32.Parse(node.InnerText); break;
            case "KeySetting11": g_KeySetting[11] = Int32.Parse(node.InnerText); break;
            case "KeySetting12": g_KeySetting[12] = Int32.Parse(node.InnerText); break;
            case "KeySetting13": g_KeySetting[13] = Int32.Parse(node.InnerText); break;
            case "KeySetting14": g_KeySetting[14] = Int32.Parse(node.InnerText); break;
            case "KeySetting15": g_KeySetting[15] = Int32.Parse(node.InnerText); break;

            case "ButtonName0": g_ButtonName[0] = node.InnerText; break;
            case "ButtonName1": g_ButtonName[1] = node.InnerText; break;
            case "ButtonName2": g_ButtonName[2] = node.InnerText; break;
            case "ButtonName3": g_ButtonName[3] = node.InnerText; break;
            case "ButtonName4": g_ButtonName[4] = node.InnerText; break;
            case "ButtonName5": g_ButtonName[5] = node.InnerText; break;
            case "ButtonName6": g_ButtonName[6] = node.InnerText; break;
            case "ButtonName7": g_ButtonName[7] = node.InnerText; break;
            case "ButtonName8": g_ButtonName[8] = node.InnerText; break;
            case "ButtonName9": g_ButtonName[9] = node.InnerText; break;
            case "ButtonName10": g_ButtonName[10] = node.InnerText; break;
            case "ButtonName11": g_ButtonName[11] = node.InnerText; break;
            case "ButtonName12": g_ButtonName[12] = node.InnerText; break;
            case "ButtonName13": g_ButtonName[13] = node.InnerText; break;
            case "ButtonName14": g_ButtonName[14] = node.InnerText; break;
            case "ButtonName15": g_ButtonName[15] = node.InnerText; break;

            case "colorButton0": strResult = node.InnerText.Split(','); g_colorButton[0] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton1": strResult = node.InnerText.Split(','); g_colorButton[1] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton2": strResult = node.InnerText.Split(','); g_colorButton[2] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton3": strResult = node.InnerText.Split(','); g_colorButton[3] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton4": strResult = node.InnerText.Split(','); g_colorButton[4] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton5": strResult = node.InnerText.Split(','); g_colorButton[5] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton6": strResult = node.InnerText.Split(','); g_colorButton[6] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton7": strResult = node.InnerText.Split(','); g_colorButton[7] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton8": strResult = node.InnerText.Split(','); g_colorButton[8] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton9": strResult = node.InnerText.Split(','); g_colorButton[9] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton10": strResult = node.InnerText.Split(','); g_colorButton[10] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton11": strResult = node.InnerText.Split(','); g_colorButton[11] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton12": strResult = node.InnerText.Split(','); g_colorButton[12] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton13": strResult = node.InnerText.Split(','); g_colorButton[13] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton14": strResult = node.InnerText.Split(','); g_colorButton[14] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
            case "colorButton15": strResult = node.InnerText.Split(','); g_colorButton[15] = System.Drawing.Color.FromArgb(Int32.Parse(strResult[0]), Int32.Parse(strResult[1]), Int32.Parse(strResult[2])); break;
          }
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public CValueObject()
    { }
    ~CValueObject()
    { }
  }
}
