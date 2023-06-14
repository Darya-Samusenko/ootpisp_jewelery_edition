using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace oop_crud
{
    public class DataSaver
    {
        BaseJew curr_jew;

        public void make_new_object_form(Type jew_type, Control.ControlCollection fields_to_save)
        {
            //здесь надо разложить поля и сохранить их
            var method = jew_type.GetConstructors();//получаю все конструкторы
            //создаю через вызов пустого конструктора
            curr_jew = method[0].Invoke(null) as BaseJew;
            //может можно сначала сделать list, а потом конструктор?
            List<FieldInfo> all_fields = new List<FieldInfo>(jew_type.GetFields());
            foreach (Control src in fields_to_save)
            {
                bool is_found = false;
                for (int i = 0; i < all_fields.Count && (!is_found); i++)
                {
                    if (src.Name.Contains(all_fields[i].Name))
                    {
                        is_found = true;
                        Type val_type = all_fields[i].FieldType;

                        if (val_type.Name == "Boolean")
                        {
                            CheckBox val = (CheckBox)src;
                            all_fields[i].SetValue(curr_jew, val.Checked);
                        }
                        if (val_type.Name == "String")
                        {
                            all_fields[i].SetValue(curr_jew, src.Text);
                        }
                        if (val_type.Name == "Int32")
                        {
                            all_fields[i].SetValue(curr_jew, Convert.ToInt32(src.Text));
                        }
                        if (val_type.Name == "Double")
                        {
                            all_fields[i].SetValue(curr_jew, Convert.ToDouble(src.Text));
                        }
                        if (val_type.IsEnum)
                        {
                            ComboBox val_holder = (ComboBox)src;
                            String enum_name = val_holder.SelectedItem as String;
                            FieldInfo[] all_enum_vals = val_type.GetFields();
                            int j;
                            for (j = 0; (j < all_enum_vals.Length) && (all_enum_vals[j].Name != enum_name); j++) { }
                            if (j == all_enum_vals.Length)
                                j = all_enum_vals.Length - 1;
                            var n_obj = val_type.GetEnumValues();
                            var n_val = n_obj.GetValue(j - 1);
                            all_fields[i].SetValue(curr_jew, n_val);
                        }
                        if (val_type.IsClass && val_type.Name != "String")
                        {
                            if (curr_jew.has_stones)//только при этом условии надо обработать
                            {
                                //здесь обрабатываем панель
                                Stone n_stone = new Stone();
                                var stone_fields = src.Controls;
                                var fields = n_stone.GetType().GetFields().ToList();
                                foreach (Control pan_src in stone_fields)
                                {
                                    bool pan_found = false;
                                    for (int j = 0; j < fields.Count; j++)
                                    {
                                        if (pan_src.Name.Contains(fields[j].Name))
                                        {
                                            pan_found = true;
                                            Type val_tp = fields[j].FieldType;
                                            if (val_tp.Name == "Double")
                                            {
                                                fields[j].SetValue(n_stone, Convert.ToDouble(pan_src.Text));
                                            }
                                            if (val_tp.Name == "String")
                                            {
                                                fields[j].SetValue(n_stone, pan_src.Text);
                                            }
                                            fields.RemoveAt(j);
                                        }
                                    }

                                }
                                curr_jew.incr = n_stone;
                            }

                        }
                        //удаляем поле из списков
                        all_fields.RemoveAt(i);
                    }

                }
            }
        }
        public DataSaver()//если нужна доп логика
        {
            
        }

        public BaseJew get_new_jew()
        {
            return this.curr_jew;
        }
    }

}
