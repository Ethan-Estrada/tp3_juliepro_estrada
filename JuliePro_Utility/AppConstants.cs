﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Utility
{
    public static class AppConstants
    {
        public static string ImagePath = @"\images\upload\";
        public static string ImagePathView = @"/images/upload/";
        public static string ImageGeneric = "GenericTrainer.png";
        public static string Success = "Success";
        public const string Error = "Error";

        public static string SuperAdminRole { get; set; }
        public static string TrainerRole { get; set; }
    }
}
