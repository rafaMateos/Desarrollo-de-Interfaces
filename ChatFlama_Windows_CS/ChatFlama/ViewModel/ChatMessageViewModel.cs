﻿using ChatFlama.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatFlama.ViewModel
{
    public class ChatMessageViewModel
    {
       public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        
    }
}
