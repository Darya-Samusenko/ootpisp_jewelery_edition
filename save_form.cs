using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace oop_crud
{
    //тут надо применить 2 плагина на шифрование и сериализацию
    //плагины надо взять из dll (!своих)
    //ключ для шифрования и дешифрования константный (в коде плагина?)
    public partial class save_form : Form
    {
        private Common_serializer curr_serializer;
        private List<BaseJew> jew;
        private SerializationControl serialisation_manager;
        private List<string> all_serializers;
        private CipherControl cipher_manager;
        public save_form(main_form src)
        {
            jew = src.jewelery;
            InitializeComponent();
        }

        private void save_form_Load(object sender, EventArgs e)
        {
            serialisation_manager = new SerializationControl();
            cipher_manager = new CipherControl();
            cipher_manager.GetAllPlugins();
            all_serializers = serialisation_manager.GetAllFileExtensions();
            ser_choice.Items.Clear();
            ser_choice.Items.AddRange(all_serializers.ToArray());
            cipher_choice.Items.Clear();
            cipher_choice.Items.AddRange(cipher_manager.GetAllPlugins().ToArray());
            cipher_choice.DropDownStyle = ComboBoxStyle.DropDownList;
            ser_choice.DropDownStyle = ComboBoxStyle.DropDownList;
            cipher_panel.Visible = false;
        }

        private void cipher_needed_CheckedChanged(object sender, EventArgs e)
        {
            //скрываю/показываю в зависимоти от состояния
            cipher_panel.Visible = (sender as RadioButton).Checked;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (ser_choice.SelectedItem == null)
                ser_choice.SelectedIndex = 0;
            if(save_dlg.ShowDialog() == DialogResult.OK)
            {
                filename = save_dlg.FileName;
                curr_serializer = serialisation_manager.GetRequiredSerializer(ser_choice.SelectedItem.ToString());
                if(curr_serializer != null)
                {
                    filename = filename + curr_serializer.GetExtension();
                    if (cipher_needed.Checked)
                    {
                        if (cipher_choice.SelectedItem == null)
                            cipher_choice.SelectedIndex = 0;
                        filename = filename + cipher_choice.SelectedItem;
                    }
                    curr_serializer.Serialize(jew, filename);//сама сериализация
                }
                if (cipher_needed.Checked)//если еще сверху выбрано шифрование
                {
                    
                    CipherControl control = new CipherControl();
                    control.cipher_file(filename, cipher_choice.SelectedItem.ToString());
                }
            }
            this.Close();
        }
    }
}
