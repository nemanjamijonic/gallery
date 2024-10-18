﻿using Common.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface IGalleryService
    { 

        [OperationContract]
        List<Gallery> GetAllGalleries();

        [OperationContract]
        List<Gallery> GetAllGalleriesFromDb();

        [OperationContract]
        bool CreateNewGallery(Gallery newGallery);

        [OperationContract]
        bool DeleteGallery(string galleryPIB);

        [OperationContract]
        bool SaveGalleryChanges(Gallery gallery);
        [OperationContract]
        Gallery GetGalleryByPIB(string pib);

        [OperationContract]
        Gallery CreateGallery(Gallery newGallery);
    }
}
