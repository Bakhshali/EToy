﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constants
{
    public static class ErrorMessages
    {
        public const string IdError = "Specified Id was not found!";
        public const string EntityNotFound = "Item was not found";
        public const string NotBeingAbleToUpdate = "Could not update the item";
        public const string SourceCodeChange = "Source code has been changed";
        public const string CouldNotDelete = "Specified item could not be deleted";
        public const string CouldNotAddToDatabase = "Something went wrong";

        public const string ChooseImage = "Zəhmət olmasa şəkil seçin*";
        public const string MistakeImage = "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!";

    }
}
