using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Linq;

namespace TXSoftware.DataObjectsNetEntityModel.Common.UIEditors.Forms
{
    public partial class FlagsEditorControl : UserControl
	{
        FlagsEditor Editor = null;
		IWindowsFormsEditorService _Service = null;
		object _Value;
		long leftOver = 0;
		bool cancelFlag = false;
        private EnumValueContainer noneItem;

		public FlagsEditorControl(FlagsEditor editor)
		{
		    InitializeComponent();
		    btnReset.Image = images.Images[0];
		    btnCancel.Image = images.Images[1];
            btnOk.Image = images.Images[2];
			Editor = editor;
		}

		void okeyButton_Click(object sender, EventArgs e)
		{
			// okey button pressed so CloseDropDown, this will finish the edit operation
			_Service.CloseDropDown();
		}

		void buttonReset_Click(object sender, EventArgs e)
		{
			// reset button pressed, so reload values
			Begin(_Service, _Value);
		}

		void cancelButton_Click(object sender, EventArgs e)
		{
			// cancel button pressed, close drop down but
			// also set cancelFlag to true
			cancelFlag = true;
			_Service.CloseDropDown();
		}

		// begin edit operation
		public void Begin(IWindowsFormsEditorService service, object value)
		{
			_Service = service;
			lvwItems.Items.Clear();

			Type enumType = value.GetType();
			//Array values = Enum.GetValues(enumType);
           
		    var enumItems = EnumType.GetValues(enumType);
		    var enumFields = (from field in enumType.GetFields()
		                     let flagsEnumItemAttr =
                                 field.GetCustomAttributes(typeof(FlagsEnumItem), false).OfType<FlagsEnumItem>().SingleOrDefault()
		                     where field.FieldType == enumType &&
		                           flagsEnumItemAttr != null
		                     select new {field.Name, flagsEnumItemAttr}).ToDictionary(arg => arg.Name, arg1 => arg1.flagsEnumItemAttr);

		    // prepare list
			long current = Convert.ToInt64(value);

            this.noneItem = new EnumValueContainer(enumType, 0);

			//for (int i = 0; i < values.Length; i++)
            foreach (Enum enumItem in enumItems)
            {
                //long val = Convert.ToInt64(values.GetValue(i));
				long val = Convert.ToInt64(enumItem);

                string enumName = Enum.GetName(enumType, enumItem);
                if (enumFields.ContainsKey(enumName))
                {
                    FlagsEnumItem enumField = enumFields[enumName];
                    if (enumField.IsNoneItem)
                    {
                        this.noneItem = new EnumValueContainer(enumType, val);
                    }
                    
                    if (enumField.ExcludeFromEditor)
                    {
                        continue;
                    }
                }

				bool check = false;
				if (val == 0)
					check = (current == 0);
				else
				{
					check = ((current & val) == val);
					if (check)
						current &= ~val;
				}

				lvwItems.Items.Add(new EnumValueContainer(enumType, val), check);
			}
			leftOver = current;
			_Value = value;
		}

		// end edit operation
		public void End()
		{
			cancelFlag = false;
			_Service = null;
			_Value = 0;
			leftOver = 0;
		}

		// value which will be calculated from the checked items list
		public object Value
		{
			get
			{
				// if cancel flag set, return original value
				if (cancelFlag)
					return _Value;

				long value = 0;
				for (int i = 0; i < lvwItems.CheckedItems.Count; i++)
				{
					EnumValueContainer container = lvwItems.CheckedItems[i] as EnumValueContainer;
					value |= Convert.ToInt64(container.Value);
				}

				return value | leftOver;
			}
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (((keyData & Keys.KeyCode) == Keys.Return) 
				&& ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
			{
				_Service.CloseDropDown();
				return true;
			}
			if (((keyData & Keys.KeyCode) == Keys.Escape) 
				&& ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
			{
				cancelFlag = true;
				_Service.CloseDropDown();
				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		// container class for the enum values
		private class EnumValueContainer
		{
			Type _Type;
			object _Value = 0;

			public EnumValueContainer(Type type, object value)
			{
				_Type = type;
				_Value = value;
			}

			// return the Name of the Enum member according to its value
			public override string ToString()
			{
				return Enum.GetName(_Type, _Value);
			}

			public object Value
			{
				get { return _Value; }
			}
		}
	}
}
