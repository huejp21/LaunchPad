using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace LaunchPad
{
  public class CLaunchPad
  {
    //Member Value Area
    bool bColor = false;

    //Constructor and Destroyer
    public CLaunchPad()
    {
      //Default Button Color
      for (int i = 0; i < CValueObject.g_nThreadMax; i++)
      {
        SetButtonColor(i, System.Drawing.Color.FromArgb(0, 0, 255));
      }

      //Init Key Status
      for (int i = 0; i < (int)KeyBoard.Key_MAX; i++)
      {
        CValueObject.g_KeyStatus[i] = 0;
      }

      //Default Key set
      CValueObject.g_KeySetting[0] = (int)KeyBoard.Key_1;
      CValueObject.g_KeySetting[1] = (int)KeyBoard.Key_2;
      CValueObject.g_KeySetting[2] = (int)KeyBoard.Key_3;
      CValueObject.g_KeySetting[3] = (int)KeyBoard.Key_4;
      CValueObject.g_KeySetting[4] = (int)KeyBoard.Key_Q;
      CValueObject.g_KeySetting[5] = (int)KeyBoard.Key_W;
      CValueObject.g_KeySetting[6] = (int)KeyBoard.Key_E;
      CValueObject.g_KeySetting[7] = (int)KeyBoard.Key_R;
      CValueObject.g_KeySetting[8] = (int)KeyBoard.Key_A;
      CValueObject.g_KeySetting[9] = (int)KeyBoard.Key_S;
      CValueObject.g_KeySetting[10] = (int)KeyBoard.Key_D;
      CValueObject.g_KeySetting[11] = (int)KeyBoard.Key_F;
      CValueObject.g_KeySetting[12] = (int)KeyBoard.Key_Z;
      CValueObject.g_KeySetting[13] = (int)KeyBoard.Key_X;
      CValueObject.g_KeySetting[14] = (int)KeyBoard.Key_C;
      CValueObject.g_KeySetting[15] = (int)KeyBoard.Key_V;

      //Default SoundFile Directory
      CValueObject.g_SoundFileDirectory[0] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\1Rimshot.wav";
      CValueObject.g_SoundFileDirectory[1] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\2Snare.wav";
      CValueObject.g_SoundFileDirectory[2] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\3Kick.wav";
      CValueObject.g_SoundFileDirectory[3] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\4Hihat.wav";
      CValueObject.g_SoundFileDirectory[4] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\5Rimshot.wav";
      CValueObject.g_SoundFileDirectory[5] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\6Snare.wav";
      CValueObject.g_SoundFileDirectory[6] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\7Kick.wav";
      CValueObject.g_SoundFileDirectory[7] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\8Hihat.wav";
      CValueObject.g_SoundFileDirectory[8] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\9Rimshot.wav";
      CValueObject.g_SoundFileDirectory[9] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\10Snare.wav";
      CValueObject.g_SoundFileDirectory[10] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\11Kick.wav";
      CValueObject.g_SoundFileDirectory[11] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\12Hihat.wav";
      CValueObject.g_SoundFileDirectory[12] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\13Rimshot.wav";
      CValueObject.g_SoundFileDirectory[13] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\14Snare.wav";
      CValueObject.g_SoundFileDirectory[14] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\15Kick.wav";
      CValueObject.g_SoundFileDirectory[15] = System.IO.Directory.GetCurrentDirectory() + "\\MusicFile\\16Hihat.wav";

      //System.IO.FileInfo FileInfo = new System.IO.FileInfo(System.IO.Directory.GetCurrentDirectory() + "\\Default.xml");
      //if (FileInfo.Exists)
      //{
      //  CValueObject.LoadXML(System.IO.Directory.GetCurrentDirectory() + "\\Default.xml");
      //}
    }
    ~CLaunchPad()
    {

    }

    //button control Get Set
    public bool SetButtonValue(int nIndex, System.Windows.Forms.Button btn)
    {
      if (CValueObject.g_nThreadMax <= nIndex) { return false; }
      CValueObject.g_arrButton[nIndex] = btn;
      return true;
    }
    public System.Windows.Forms.Button GetButtonValue(int nIndex) { return CValueObject.g_arrButton[nIndex]; }

    //buttonColor Get Set
    public bool SetButtonColor(int nIndex, System.Drawing.Color colorValue)
    {
      if (CValueObject.g_nThreadMax <= nIndex) { return false; }
      CValueObject.g_colorButton[nIndex] = colorValue;
      return true;
    }
    public System.Drawing.Color GetButtonColor(bool bOn, int nIndex)
    {
      return CValueObject.g_colorButton[nIndex];
    }

    //buttonText Get Set
    public bool SetButtonText(int nIndex, string strText)
    {
      if (CValueObject.g_nThreadMax <= nIndex) { return false; }
      CValueObject.g_arrButton[nIndex].Text = strText;
      return true;
    }
    public string GetButtonText(int nIndex) { return CValueObject.g_arrButton[nIndex].Text; }

    //Input Hooking
    

    //Thread Loop Fuction
    public void CtrlBtn1()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[0]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[0]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else 
        {
        }
      }
    }
    public void CtrlBtn2()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[1]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[1]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn3()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[2]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[2]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn4()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[3]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[3]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn5()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[4]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[4]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn6()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[5]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[5]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn7()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[6]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[6]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn8()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[7]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[7]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn9()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[8]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[8]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn10()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[9]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[9]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn11()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[10]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[10]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn12()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[11]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[11]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn13()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[12]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[12]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn14()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[13]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[13]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn15()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[14]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[14]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
    public void CtrlBtn16()
    {
      while (true)
      {
        Thread.Sleep(1);
        if (CValueObject.g_KeyStatus[CValueObject.g_KeySetting[15]] == 1)
        {
          try
          {
            SoundPlayer wp = new SoundPlayer(CValueObject.g_SoundFileDirectory[15]);
            wp.PlaySync();
          }
          catch (Exception ex)
          {
            continue;
          }
        }
        else
        {
        }
      }
    }
  }

}
