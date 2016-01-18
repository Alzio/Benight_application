using Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Benight_application
{
    public class TodoEv : INotifyPropertyChanged
    {
        public static readonly string ClassName = "Event";

        public TodoEv() : this(new ParseObject(ClassName)) { }
        public TodoEv(ParseObject backingObject)
        {
            if (backingObject.ClassName != ClassName)
            {
                throw new ArgumentException("Must create TodoItems with the proper ClassName");
            }
            //this.BackingObject = backingObject;
            BackingObject = backingObject;
        }

        public ParseObject BackingObject { get; private set; }

        public bool IsDirty
        {
            get
            {
                return BackingObject.IsDirty;
            }
        }

        public string My_EventName
        {
            get
            {
                return BackingObject.ContainsKey("name") ? BackingObject.Get<string>("name") : null;
                
            }
            set
            {
                if (value != My_EventName)
                {
                    BackingObject["name"] = value;
                    //OnPropertyChanged();
                }
            }
        }

        public string My_EvDescription
        {
            get
            {
                return BackingObject.ContainsKey("description") ? BackingObject.Get<string>("description") : null;
            }
            set
            {
                if (value != My_EvDescription)
                {
                    BackingObject["description"] = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var del = PropertyChanged;
            if (del != null)
            {
                del(this, new PropertyChangedEventArgs(propertyName));
                del(this, new PropertyChangedEventArgs("IsDirty"));
            }
        }

        public async Task SaveAsync()
        {
            await BackingObject.SaveAsync();
            OnPropertyChanged("IsDirty");
        }

        public void Revert()
        {
            BackingObject.Revert();
            OnPropertyChanged(String.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
