using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchPad
{
  public partial class SettingForm : Form
  {
    public System.Windows.Forms.TextBox[] m_TextColor = new System.Windows.Forms.TextBox[CValueObject.g_nThreadMax];
    public System.Windows.Forms.Button[] m_ButtonKeySet = new System.Windows.Forms.Button[CValueObject.g_nThreadMax];

    //Setting Value Buffer
    public int[] m_HotKeySetting = new int[CValueObject.g_nThreadMax];
    public System.Windows.Forms.TextBox[] m_TextName = new System.Windows.Forms.TextBox[CValueObject.g_nThreadMax];
    public Color[] m_ColorSet = new Color[CValueObject.g_nThreadMax];
    public System.Windows.Forms.TextBox[] m_TextDirectory = new System.Windows.Forms.TextBox[CValueObject.g_nThreadMax];

    public SettingForm()
    {
      InitializeComponent();
    }

    private void SettingForm_Load(object sender, EventArgs e)
    {
      this.KeyPreview = true;

      m_ButtonKeySet[0] = Btn_HotKey1;
      m_ButtonKeySet[1] = Btn_HotKey2;
      m_ButtonKeySet[2] = Btn_HotKey3;
      m_ButtonKeySet[3] = Btn_HotKey4;
      m_ButtonKeySet[4] = Btn_HotKey5;
      m_ButtonKeySet[5] = Btn_HotKey6;
      m_ButtonKeySet[6] = Btn_HotKey7;
      m_ButtonKeySet[7] = Btn_HotKey8;
      m_ButtonKeySet[8] = Btn_HotKey9;
      m_ButtonKeySet[9] = Btn_HotKey10;
      m_ButtonKeySet[10] = Btn_HotKey11;
      m_ButtonKeySet[11] = Btn_HotKey12;
      m_ButtonKeySet[12] = Btn_HotKey13;
      m_ButtonKeySet[13] = Btn_HotKey14;
      m_ButtonKeySet[14] = Btn_HotKey15;
      m_ButtonKeySet[15] = Btn_HotKey16;

      m_TextName[0] = txt_ButtonName1;
      m_TextName[1] = txt_ButtonName2;
      m_TextName[2] = txt_ButtonName3;
      m_TextName[3] = txt_ButtonName4;
      m_TextName[4] = txt_ButtonName5;
      m_TextName[5] = txt_ButtonName6;
      m_TextName[6] = txt_ButtonName7;
      m_TextName[7] = txt_ButtonName8;
      m_TextName[8] = txt_ButtonName9;
      m_TextName[9] = txt_ButtonName10;
      m_TextName[10] = txt_ButtonName11;
      m_TextName[11] = txt_ButtonName12;
      m_TextName[12] = txt_ButtonName13;
      m_TextName[13] = txt_ButtonName14;
      m_TextName[14] = txt_ButtonName15;
      m_TextName[15] = txt_ButtonName16;

      m_TextDirectory[0] = txt_SoundDirectory1;
      m_TextDirectory[1] = txt_SoundDirectory2;
      m_TextDirectory[2] = txt_SoundDirectory3;
      m_TextDirectory[3] = txt_SoundDirectory4;
      m_TextDirectory[4] = txt_SoundDirectory5;
      m_TextDirectory[5] = txt_SoundDirectory6;
      m_TextDirectory[6] = txt_SoundDirectory7;
      m_TextDirectory[7] = txt_SoundDirectory8;
      m_TextDirectory[8] = txt_SoundDirectory9;
      m_TextDirectory[9] = txt_SoundDirectory10;
      m_TextDirectory[10] = txt_SoundDirectory11;
      m_TextDirectory[11] = txt_SoundDirectory12;
      m_TextDirectory[12] = txt_SoundDirectory13;
      m_TextDirectory[13] = txt_SoundDirectory14;
      m_TextDirectory[14] = txt_SoundDirectory15;
      m_TextDirectory[15] = txt_SoundDirectory16;

      m_TextColor[0] = txt_ButtonColor1;
      m_TextColor[1] = txt_ButtonColor2;
      m_TextColor[2] = txt_ButtonColor3;
      m_TextColor[3] = txt_ButtonColor4;
      m_TextColor[4] = txt_ButtonColor5;
      m_TextColor[5] = txt_ButtonColor6;
      m_TextColor[6] = txt_ButtonColor7;
      m_TextColor[7] = txt_ButtonColor8;
      m_TextColor[8] = txt_ButtonColor9;
      m_TextColor[9] = txt_ButtonColor10;
      m_TextColor[10] = txt_ButtonColor11;
      m_TextColor[11] = txt_ButtonColor12;
      m_TextColor[12] = txt_ButtonColor13;
      m_TextColor[13] = txt_ButtonColor14;
      m_TextColor[14] = txt_ButtonColor15;
      m_TextColor[15] = txt_ButtonColor16;

      UpdateData();
    }

    private void btn_SettingClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void btn_SettingApply_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < CValueObject.g_nThreadMax; i++)
      {
        CValueObject.g_ButtonName[i] = m_TextName[i].Text;
        CValueObject.g_colorButton[i] = m_ColorSet[i];
        CValueObject.g_SoundFileDirectory[i] = m_TextDirectory[i].Text;
        CValueObject.g_KeySetting[i] = m_HotKeySetting[i];
        CValueObject.g_arrButton[i].BackColor = m_ColorSet[i];
      }
    }

    private void btn_SettingSave_Click(object sender, EventArgs e)
    {
      SaveFileDialog fileDlg = new SaveFileDialog();
      fileDlg.Filter = "XML Files(*.xml)|*.xml";
      fileDlg.DefaultExt = "*.xml";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Directory";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        CValueObject.g_SettingFileDirectory = fileDlg.FileName;
        System.IO.Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(fileDlg.FileName));
        if (CValueObject.CreateXML(fileDlg.FileName)) { MessageBox.Show("Save Success."); }
        else { MessageBox.Show("Save Fail."); }
      }
    }

    private void btn_SettingLoad_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "XML Files(*.xml)|*.xml";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Directory";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        CValueObject.g_SettingFileDirectory = fileDlg.FileName;
        System.IO.Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(fileDlg.FileName));
        if (CValueObject.LoadXML(fileDlg.FileName)) { MessageBox.Show("Load Success."); }
        else { MessageBox.Show("Load Fail."); }
      }
    }

    private void SettingForm_KeyDown(object sender, KeyEventArgs e)
    {

    }

    private void SettingForm_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

    public void UpdateData() 
    {
      for (int i = 0; i < CValueObject.g_nThreadMax; i++)
      {
        m_ColorSet[i] = CValueObject.g_colorButton[i];
        m_TextColor[i].Text = string.Format("{0},{1},{2}", CValueObject.g_colorButton[i].R, CValueObject.g_colorButton[i].G, CValueObject.g_colorButton[i].B);
        m_ButtonKeySet[i].Text = ConvertKey(CValueObject.g_KeySetting[i]);
        m_TextName[i].Text = CValueObject.g_ButtonName[i];
        m_TextDirectory[i].Text = CValueObject.g_SoundFileDirectory[i];
      }
    }

    private string ConvertKey(int nKeyValue)
    {
      string strData = "";
      switch (nKeyValue)
      {
        case 0: strData = "ESC"; break;
        case 1: strData = "F1"; break;
        case 2: strData = "F2"; break;
        case 3: strData = "F3"; break;
        case 4: strData = "F4"; break;
        case 5: strData = "F5"; break;
        case 6: strData = "F6"; break;
        case 7: strData = "F7"; break;
        case 8: strData = "F8"; break;
        case 9: strData = "F9"; break;
        case 10: strData = "F10"; break;
        case 11: strData = "F11"; break;
        case 12: strData = "F12"; break;
        case 13: strData = "PrintScreen"; break;
        case 14: strData = "ScrollLock"; break;
        case 15: strData = "PauseBreak"; break;
        case 16: strData = "Tilde"; break;
        case 17: strData = "1"; break;
        case 18: strData = "2"; break;
        case 19: strData = "3"; break;
        case 20: strData = "4"; break;
        case 21: strData = "5"; break;
        case 22: strData = "6"; break;
        case 23: strData = "7"; break;
        case 24: strData = "8"; break;
        case 25: strData = "9"; break;
        case 26: strData = "0"; break;
        case 27: strData = "Hyphen"; break;
        case 28: strData = "Plus"; break;
        case 29: strData = "BackSpace"; break;
        case 30: strData = "Tap"; break;
        case 31: strData = "Q"; break;
        case 32: strData = "W"; break;
        case 33: strData = "E"; break;
        case 34: strData = "R"; break;
        case 35: strData = "T"; break;
        case 36: strData = "Y"; break;
        case 37: strData = "U"; break;
        case 38: strData = "I"; break;
        case 39: strData = "O"; break;
        case 40: strData = "P"; break;
        case 41: strData = "LSquareBracket"; break;
        case 42: strData = "RSquareBracket"; break;
        case 43: strData = "BackSlash"; break;
        case 44: strData = "CapsLock"; break;
        case 45: strData = "A"; break;
        case 46: strData = "S"; break;
        case 47: strData = "D"; break;
        case 48: strData = "F"; break;
        case 49: strData = "G"; break;
        case 50: strData = "H"; break;
        case 51: strData = "J"; break;
        case 52: strData = "K"; break;
        case 53: strData = "L"; break;
        case 54: strData = "Semicolon"; break;
        case 55: strData = "Apostrophe"; break;
        case 56: strData = "Enter"; break;
        case 57: strData = "LShift"; break;
        case 58: strData = "Z"; break;
        case 59: strData = "X"; break;
        case 60: strData = "C"; break;
        case 61: strData = "V"; break;
        case 62: strData = "B"; break;
        case 63: strData = "N"; break;
        case 64: strData = "M"; break;
        case 65: strData = "Comma"; break;
        case 66: strData = "Period"; break;
        case 67: strData = "Slash"; break;
        case 68: strData = "RShift"; break;
        case 69: strData = "LCtrl"; break;
        case 70: strData = "LWin"; break;
        case 71: strData = "LAlt"; break;
        case 72: strData = "SpaceBar"; break;
        case 73: strData = "RAlt"; break;
        case 74: strData = "FN"; break;
        case 75: strData = "RCtrl"; break;
        case 76: strData = "Insert"; break;
        case 77: strData = "Home"; break;
        case 78: strData = "PageUp"; break;
        case 79: strData = "Delete"; break;
        case 80: strData = "End"; break;
        case 81: strData = "PageDown"; break;
        case 82: strData = "UpArrow"; break;
        case 83: strData = "LeftArrow"; break;
        case 84: strData = "DownArrow"; break;
        case 85: strData = "RightArrow"; break;
        case 86: strData = "NumberLock"; break;
        case 87: strData = "NSlash"; break;
        case 88: strData = "NAsterisk"; break;
        case 89: strData = "NHyphen"; break;
        case 90: strData = "N7"; break;
        case 91: strData = "N8"; break;
        case 92: strData = "N9"; break;
        case 93: strData = "NPlus"; break;
        case 94: strData = "N4"; break;
        case 95: strData = "N5"; break;
        case 96: strData = "N6"; break;
        case 97: strData = "N1"; break;
        case 98: strData = "N2"; break;
        case 99: strData = "N3"; break;
        case 100: strData = "NEnter"; break;
        case 101: strData = "N0"; break;
        case 102: strData = "NPeriod"; break;
      }
      return strData;
    }










    //////////////
    //ColorButton
    /// //////////
    private void btn_ButtonColor_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[0] = dlg.Color;
        m_TextColor[0].Text = string.Format("{0},{1},{2}", m_ColorSet[0].R, m_ColorSet[0].G, m_ColorSet[0].B);
      }
    }

    private void btn_ButtonColor2_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[1] = dlg.Color;
        m_TextColor[1].Text = string.Format("{0},{1},{2}", m_ColorSet[1].R, m_ColorSet[1].G, m_ColorSet[1].B);
      }
    }

    private void btn_ButtonColor3_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[2] = dlg.Color;
        m_TextColor[2].Text = string.Format("{0},{1},{2}", m_ColorSet[2].R, m_ColorSet[2].G, m_ColorSet[2].B);
      }
    }

    private void btn_ButtonColor4_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[3] = dlg.Color;
        m_TextColor[3].Text = string.Format("{0},{1},{2}", m_ColorSet[3].R, m_ColorSet[3].G, m_ColorSet[3].B);
      }
    }

    private void btn_ButtonColor5_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[4] = dlg.Color;
        m_TextColor[4].Text = string.Format("{0},{1},{2}", m_ColorSet[4].R, m_ColorSet[4].G, m_ColorSet[4].B);
      }
    }

    private void btn_ButtonColor6_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[5] = dlg.Color;
        m_TextColor[5].Text = string.Format("{0},{1},{2}", m_ColorSet[5].R, m_ColorSet[5].G, m_ColorSet[5].B);
      }
    }

    private void btn_ButtonColor7_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[6] = dlg.Color;
        m_TextColor[6].Text = string.Format("{0},{1},{2}", m_ColorSet[6].R, m_ColorSet[6].G, m_ColorSet[6].B);
      }
    }

    private void btn_ButtonColor8_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[7] = dlg.Color;
        m_TextColor[7].Text = string.Format("{0},{1},{2}", m_ColorSet[7].R, m_ColorSet[7].G, m_ColorSet[7].B);
      }
    }

    private void btn_ButtonColor9_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[8] = dlg.Color;
        m_TextColor[8].Text = string.Format("{0},{1},{2}", m_ColorSet[8].R, m_ColorSet[8].G, m_ColorSet[8].B);
      }
    }

    private void btn_ButtonColor10_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[9] = dlg.Color;
        m_TextColor[9].Text = string.Format("{0},{1},{2}", m_ColorSet[9].R, m_ColorSet[9].G, m_ColorSet[9].B);
      }
    }

    private void btn_ButtonColor11_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[10] = dlg.Color;
        m_TextColor[10].Text = string.Format("{0},{1},{2}", m_ColorSet[10].R, m_ColorSet[10].G, m_ColorSet[10].B);
      }
    }

    private void btn_ButtonColor12_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[11] = dlg.Color;
        m_TextColor[11].Text = string.Format("{0},{1},{2}", m_ColorSet[11].R, m_ColorSet[11].G, m_ColorSet[11].B);
      }
    }

    private void btn_ButtonColor13_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[12] = dlg.Color;
        m_TextColor[12].Text = string.Format("{0},{1},{2}", m_ColorSet[12].R, m_ColorSet[12].G, m_ColorSet[12].B);
      }
    }

    private void btn_ButtonColor14_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[13] = dlg.Color;
        m_TextColor[13].Text = string.Format("{0},{1},{2}", m_ColorSet[13].R, m_ColorSet[13].G, m_ColorSet[13].B);
      }
    }

    private void btn_ButtonColor15_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[14] = dlg.Color;
        m_TextColor[14].Text = string.Format("{0},{1},{2}", m_ColorSet[14].R, m_ColorSet[14].G, m_ColorSet[14].B);
      }
    }

    private void btn_ButtonColor16_Click(object sender, EventArgs e)
    {
      ColorDialog dlg = new ColorDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        m_ColorSet[15] = dlg.Color;
        m_TextColor[15].Text = string.Format("{0},{1},{2}", m_ColorSet[15].R, m_ColorSet[15].G, m_ColorSet[15].B);
      }
    }



    //////////////
    //HotKeyButton
    /// //////////
    private void Btn_HotKey1_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[0], ref strBuffer);
        m_ButtonKeySet[0].Text = strBuffer;
      }
    }

    private void Btn_HotKey2_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[1], ref strBuffer);
        m_ButtonKeySet[1].Text = strBuffer;
      }
    }

    private void Btn_HotKey3_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[2], ref strBuffer);
        m_ButtonKeySet[2].Text = strBuffer;
      }
    }

    private void Btn_HotKey4_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[3], ref strBuffer);
        m_ButtonKeySet[3].Text = strBuffer;
      }
    }

    private void Btn_HotKey5_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[4], ref strBuffer);
        m_ButtonKeySet[4].Text = strBuffer;
      }
    }

    private void Btn_HotKey6_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[5], ref strBuffer);
        m_ButtonKeySet[5].Text = strBuffer;
      }
    }

    private void Btn_HotKey7_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[6], ref strBuffer);
        m_ButtonKeySet[6].Text = strBuffer;
      }
    }

    private void Btn_HotKey8_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[7], ref strBuffer);
        m_ButtonKeySet[7].Text = strBuffer;
      }
    }

    private void Btn_HotKey9_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[8], ref strBuffer);
        m_ButtonKeySet[8].Text = strBuffer;
      }
    }

    private void Btn_HotKey10_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[9], ref strBuffer);
        m_ButtonKeySet[9].Text = strBuffer;
      }
    }

    private void Btn_HotKey11_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[10], ref strBuffer);
        m_ButtonKeySet[10].Text = strBuffer;
      }
    }

    private void Btn_HotKey12_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[11], ref strBuffer);
        m_ButtonKeySet[11].Text = strBuffer;
      }
    }

    private void Btn_HotKey13_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[12], ref strBuffer);
        m_ButtonKeySet[12].Text = strBuffer;
      }
    }

    private void Btn_HotKey14_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[13], ref strBuffer);
        m_ButtonKeySet[13].Text = strBuffer;
      }
    }

    private void Btn_HotKey15_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[14], ref strBuffer);
        m_ButtonKeySet[14].Text = strBuffer;
      }
    }

    private void Btn_HotKey16_Click(object sender, EventArgs e)
    {
      KeyBoardForm dlg = new KeyBoardForm();
      string strBuffer = Btn_HotKey1.Text;
      if (dlg.ShowDialog() != DialogResult.Abort)
      {
        dlg.SetKey(ref m_HotKeySetting[15], ref strBuffer);
        m_ButtonKeySet[15].Text = strBuffer;
      }
    }



    //////////////
    //Browse Button
    /// //////////
    private void btn_SoundBrowse1_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[0].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse2_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[1].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse3_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[2].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse4_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[3].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse5_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[4].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse6_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[5].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse7_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[6].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse8_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[7].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse9_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[8].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse10_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[9].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse11_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[10].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse12_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[11].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse13_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[12].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse14_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[13].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse15_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[14].Text = fileDlg.FileName;
      }
    }

    private void btn_SoundBrowse16_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDlg = new OpenFileDialog();
      fileDlg.Filter = "All Files(*.*)|*.*|Wave FILE(*.wav)|*.wav|MP3 FILE(*.mp3)|*.mp3";
      fileDlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
      fileDlg.Title = "Select Melody File";
      if (fileDlg.ShowDialog() == DialogResult.OK)
      {
        m_TextDirectory[15].Text = fileDlg.FileName;
      }
    }
  }
}
