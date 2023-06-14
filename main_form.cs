using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace oop_crud
{
    public partial class main_form : Form
    {
        public main_form()
        {
            //динамическое подключение плагинов (все директивы using убрала)
            Assembly.LoadFrom("E:\\projects c plysplus\\cezar_lib\\bin\\Debug\\cezar_lib.dll");
            Assembly.LoadFrom("E:\\projects c plysplus\\cipher_plugin_lfsr\\cipher_plugin_lfsr\\bin\\Debug\\cipher_plugin_lfsr.dll");

            InitializeComponent();
        }

        private int items_count;
        private int curr_item;
        private bool is_saved;
        private bool is_new;

        public List<BaseJew> jewelery;
        //хранит все классы пространства имен
        private List<Type> classes_list;
        //используется для отбора нужных классов, которые можно будет создать
        private const string non_combobox_names = "LFSRManager CezarManager CipherControl <>c__DisplayClass4_0 TEXTSerializer  JSONSerializer BINSerializer Common_serializer save_form SerializationControl DataSaver main_form Stone main_form+field_type main_from+<>c hold_type clasp_type BaseJew";
        private void get_items_for_combobox(ComboBox dest)
        {
            dest.Items.Clear();
            classes_list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "oop_crud").ToList();
            for (int i = 0; i < classes_list.Count(); i++)
            {
                if ((classes_list[i].IsAbstract == false) && (!non_combobox_names.Contains(classes_list[i].Name)))
                {
                    if (classes_list[i].BaseType.Name != "creators")
                        dest.Items.Add(classes_list[i].Name);
                }
            }
        }
        private void main_form_Shown(object sender, EventArgs e)
        {
            //items_count = 1;//для теста
            if (items_count > 0)
            {
                curr_element_panel.Visible = true;
                curr_element_panel.Enabled = true;
                controls_panel.Visible = true;

            }

        }

        private const int START_CD_X = 10;
        private const int START_CD_Y = 10;
        private const int SPACE_BETWEEN = 10;
        private const int WIDTH_STANDARD = 300;//размер всей панели - 678
        private const int HEIGHT_STANDARD = 40;



        private Panel make_panel(Type class_field)
        {
            Panel new_element = new Panel();
            new_element.Width = WIDTH_STANDARD + SPACE_BETWEEN;
            FieldInfo[] el_fields = class_field.GetFields();
            new_element.Height = (el_fields.Length) * (HEIGHT_STANDARD + SPACE_BETWEEN) + SPACE_BETWEEN;
            int item_num = 0;
            int curr_x = START_CD_X;
            int curr_y = START_CD_Y;
            while (item_num < el_fields.Length)
            {
                Type field_type = el_fields[item_num].FieldType;
                Control panel_field = null;
                if (field_type.Name == "Double")
                {
                    panel_field = new TextBox();
                    panel_field.Text = el_fields[item_num].Name;
                    panel_field.KeyPress += keypress_double_event;
                }
                if (field_type.Name == "String")
                {
                    panel_field = new TextBox();
                    panel_field.Text = el_fields[item_num].Name;
                }
                if (panel_field != null)
                {
                    panel_field.Name = el_fields[item_num].Name + "_" + panel_field.GetType().Name;
                    panel_field.Location = new Point(curr_x, curr_y);
                    panel_field.Width = WIDTH_STANDARD;
                    panel_field.Height = HEIGHT_STANDARD;
                    panel_field.Visible = true;
                    panel_field.Enabled = true;
                    new_element.Controls.Add(panel_field);
                    curr_y = curr_y + SPACE_BETWEEN + HEIGHT_STANDARD;
                }

                if (curr_y >= curr_element_panel.Height)
                {
                    curr_y = START_CD_Y;
                    curr_x = curr_x + WIDTH_STANDARD + SPACE_BETWEEN;
                }
                item_num++;
            }
            return new_element;
        }


        private void keypress_int_event(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if (key > 57 || key < 48)
                e.Handled = true;
        }

        private void keypress_double_event(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if ((key > 57 || key < 48) && (key != ','))
                e.Handled = true;
        }

        private Control get_needed_panel()
        {
            for (int i = 0; i < fields_panel.Controls.Count; i++)
            {

                if (fields_panel.Controls[i].GetType().Name == "Panel")
                    return fields_panel.Controls[i];
            }
            return null;
        }
        private void checkbox_changed(object sender, EventArgs e)
        {
            Control changed_panel = get_needed_panel();
            if (changed_panel != null)
            {
                if ((sender as CheckBox).Checked)
                {
                    changed_panel.Visible = true;
                }
                else
                {
                    changed_panel.Visible = false;
                }
            }
        }
        private void construct_curr_element_panel(Panel dest, Type element)
        {
            FieldInfo[] fields = element.GetFields();
            dest.Controls.Clear();
            int item_num = 0;
            int curr_x = START_CD_X;
            int curr_y = START_CD_Y;
            while (item_num < fields.Length)
            {
                Type field_type = fields[item_num].FieldType;
                Control n_field = null;
                if ((field_type.Name == "Stone"))//когда надо сделать панель ( только для Stone)
                {
                    n_field = make_panel(field_type);
                }
                if (field_type.Name == "Boolean")
                {
                    n_field = new CheckBox();
                    var n_check = new CheckBox();
                    n_check.Text = fields[item_num].Name;
                    if (n_check.Text == "has_stones")
                    {
                        n_check.CheckedChanged += checkbox_changed;
                    }

                    n_field = n_check;
                }
                if (field_type.Name == "Double")
                {
                    n_field = new TextBox();
                    n_field.Text = fields[item_num].Name;
                    n_field.KeyPress += keypress_double_event;

                }
                if (field_type.Name == "Int32")
                {
                    n_field = new TextBox();
                    n_field.Text = fields[item_num].Name;
                    n_field.KeyPress += keypress_int_event;

                }
                if (field_type.Name == "String")
                {
                    n_field = new TextBox();
                    n_field.Text = fields[item_num].Name;
                }
                if (field_type.IsEnum)
                {
                    var n_box = new ComboBox();
                    n_field = new ComboBox();
                    List<FieldInfo> enumeration = field_type.GetFields().ToList();
                    n_box.DropDownStyle = ComboBoxStyle.DropDownList;
                    for (int i = 1; i < enumeration.Count; i++)
                        n_box.Items.Add(enumeration[i].Name);//посмотри, как отображается
                    n_field = n_box;
                }
                if (n_field != null)
                {
                    n_field.Name = fields[item_num].Name + "_" + n_field.GetType().Name;
                    n_field.Location = new Point(curr_x, curr_y);
                    n_field.Width = WIDTH_STANDARD;
                    n_field.Visible = true;
                    if (n_field.GetType().Name != "Panel")
                        n_field.Height = HEIGHT_STANDARD;
                    else
                        n_field.Visible = false;
                    n_field.Enabled = true;
                    dest.Controls.Add(n_field);
                    curr_y = curr_y + SPACE_BETWEEN + n_field.Height;
                }

                if (curr_y >= curr_element_panel.Height)
                {
                    curr_y = START_CD_Y;
                    curr_x = curr_x + WIDTH_STANDARD + SPACE_BETWEEN;//случай перполнения по ширине не предусмотрен
                }
                item_num++;
                //каким-то чудом добавить нужные события
            }
        }

        private void type_field_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosen = "Ring";//пусть по умолчанию стоит кольцо
            if (type_field.SelectedItem != null)
                chosen = type_field.SelectedItem.ToString();
            fields_panel.Visible = false;
            int i;
            for (i = 0; (i < classes_list.Count()) && (classes_list[i].Name != chosen); i++) { }
            Type class_type = classes_list[i];
            construct_curr_element_panel(fields_panel, class_type);
            is_saved = false;
            fields_panel.Visible = true;
        }

        private void make_new_button_Click(object sender, EventArgs e)
        {
            is_new = true;
            if (items_count == 0)
            {
                curr_element_panel.Visible = true;
                curr_element_panel.Enabled = true;
                controls_panel.Visible = true;

            }
            else//если больше 0
            {
                fields_panel.Visible = false;
                type_field.SelectedIndex = -1;

            }
            is_saved = false;
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            items_count = 0;
            curr_element_panel.Visible = false;
            curr_element_panel.Enabled = false;
            controls_panel.Visible = false;
            get_items_for_combobox(type_field);
            jewelery = new List<BaseJew>();
        }

        private void save_object_button_Click(object sender, EventArgs e)
        {
            //надо разделить логику на 2 случая: когда уже был и когда еще не было
            if (!is_saved)
            {
                if (type_field.SelectedItem == null)
                    return;
                is_saved = true;
                Control.ControlCollection all_controls = fields_panel.Controls;

                int i;
                for (i = 0; (i < classes_list.Count()) && (classes_list[i].Name != type_field.SelectedItem.ToString()); i++) { }
                Type class_type = classes_list[i];
                DataSaver saver = new DataSaver();
                saver.make_new_object_form(class_type, all_controls);
                if (is_new)
                {
                    items_count++;
                    jewelery.Add(saver.get_new_jew());
                    curr_item = jewelery.Count - 1;
                }
                else
                {
                    jewelery.RemoveAt(curr_item);
                    jewelery.Insert(curr_item, saver.get_new_jew());
                }
                if (items_count == 1)
                    curr_item = 0;
                if (items_count > 1)
                {
                    change_item_panel.Visible = true;

                }
                else
                    change_item_panel.Visible = false;

            }
        }

        private int find_field_on_screen(Control.ControlCollection all, String field_name)
        {
            int index = -1;
            for (int i = 0; (i < all.Count) && (index < 0); i++)
                if (all[i].Name.Contains(field_name) && !all[i].GetType().Name.Contains("Panel"))
                    index = i;
            return index;
        }
        private void load_item(BaseJew curr_one)
        {
            is_new = false;
            type_field.SelectedItem = curr_one.GetType().Name;
            construct_curr_element_panel(fields_panel, curr_one.GetType());
            var all_controls = fields_panel.Controls;
            FieldInfo[] all_fields = curr_one.GetType().GetFields();
            for (int i = 0; i < all_fields.Length; i++)
            {
                int j = find_field_on_screen(all_controls, all_fields[i].Name);
                //надо обработать отдельно камень + отдельно перечисления (т.к. их строкой не сделаешь)
                if (j != -1)
                {
                    if (all_fields[i].FieldType.IsEnum)
                    {
                        var res = all_fields[i].GetValue(curr_one).ToString();
                        ComboBox lb = all_controls[j] as ComboBox;
                        lb.SelectedItem = res;
                    }
                    else
                        if (all_fields[i].FieldType.Name == "Boolean")
                    {
                        CheckBox ch = all_controls[j] as CheckBox;
                        ch.Checked = Convert.ToBoolean(all_fields[i].GetValue(curr_one));
                    }
                    else
                        all_controls[j].Text = all_fields[i].GetValue(curr_one).ToString();
                }
                else
                {
                    int z;
                    for (z = 0; z < all_controls.Count && all_controls[z].GetType().Name.Contains("Panel") == false; z++) { }
                    if (curr_one.incr != null)
                    {
                        FieldInfo[] n_fields = curr_one.incr.GetType().GetFields();
                        for (int indx = 0; indx < n_fields.Length; indx++)
                        {
                            int count = find_field_on_screen(all_controls[z].Controls, n_fields[indx].Name);
                            all_controls[z].Controls[count].Text = n_fields[indx].GetValue(curr_one.incr).ToString();

                        }
                    }
                    all_controls[z].Visible = curr_one.has_stones;
                }
            }
            is_saved = false;
        }
        private void previous_button_Click(object sender, EventArgs e)
        {
            if ((curr_item > 0) && (is_saved))
            {
                curr_item--;
                load_item(jewelery[curr_item]);
                //display
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if ((curr_item < jewelery.Count - 1) && (is_saved))//не забывай кликать
            {
                curr_item++;
                load_item(jewelery[curr_item]);
            }
        }

        private void delete_object_Click(object sender, EventArgs e)
        {
            if (items_count > 1)
            {
                items_count--;
                int new_curr;
                if (curr_item > 0)
                    new_curr = curr_item - 1;
                else
                    new_curr = curr_item;
                jewelery.RemoveAt(curr_item);
                curr_item = new_curr;
                load_item(jewelery[curr_item]);
            }
            else
            {
                if (items_count > 0)
                {
                    jewelery.RemoveAt(0);
                    curr_element_panel.Visible = false;
                    controls_panel.Visible = false;
                    curr_item = -1;
                }
            }
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items_count > 0)
            {
                save_form save_form_obj = new save_form(this);
                save_form_obj.ShowDialog();
            }

        }

        private void readyState()
        {
            controls_panel.Visible = true;
            curr_element_panel.Enabled = true;
            curr_element_panel.Visible = true;
            change_item_panel.Visible = true;
        }

        private string[] get_extensions(string filename)//передается только ИМЯ файла
        {
            string[] extensions = new string[2];
            var parts = filename.Split('.');
            extensions[0] = "." + parts[1];
            if (parts.Length == 2)
                extensions[1] = "";
            else
                extensions[1] = "." + parts[2];
            return extensions;
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //здесь должна быть загрузка
            
            if(open_dlg.ShowDialog() == DialogResult.OK)
            {
                string source_file = open_dlg.FileName;
                string[] ext = get_extensions(source_file);
                CipherControl control = new CipherControl();
                if (ext[1] != "")
                {
                    //если 2 расширения
                    
                    control.decipher_file(source_file, ext[1]);
                }
                SerializationControl manager_serialisation = new SerializationControl();
                Common_serializer curr_cerializer = manager_serialisation.GetRequiredSerializer(ext[0]);
                if(curr_cerializer != null)
                {
                    List<BaseJew> new_jew = curr_cerializer.Deserialize(source_file);
                    jewelery.Clear();
                    jewelery.AddRange(new_jew.ToArray());
                    //в самом конце
                    curr_item = 0;
                    items_count = jewelery.Count;
                    load_item(jewelery[curr_item]);
                    readyState();
                }
                if(ext[1] != "")
                {
                    control.cipher_file(source_file, ext[1]);
                }
                
            }
            
        }
    }
}
