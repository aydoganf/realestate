using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FileProcess
/// </summary>
public class FileProcess
{
    public string UploadImage(Stream streamImage, int maxWidth, int maxHeight, string path)
    {
        Bitmap resizedImage = ResizeImage(streamImage, maxWidth, maxHeight);
        string uploadedImageName = Guid.NewGuid().ToString() + ".jpg";
        resizedImage.Save(HttpContext.Current.Server.MapPath(path) + uploadedImageName, ImageFormat.Jpeg);
        return uploadedImageName;
    }

    public string UploadImageConstantSize(Stream streamImage, int width, int height, string path)
    {
        Bitmap resizedImage = ResizeImageConstant(streamImage, width, height);
        string uploadedImageName = Guid.NewGuid().ToString() + ".jpg";
        resizedImage.Save(HttpContext.Current.Server.MapPath(path) + uploadedImageName, ImageFormat.Jpeg);
        return uploadedImageName;
    }

    public void DeleteImage(string filePath)
    {
        File.Delete(HttpContext.Current.Server.MapPath(filePath));
    }

    private Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
    {
        Bitmap originalImage = new Bitmap(streamImage);
        int newWidth = originalImage.Width;
        int newHeight = originalImage.Height;
        double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

        if (aspectRatio <= 1 && originalImage.Width > maxWidth)
        {
            newWidth = maxWidth;
            newHeight = (int)Math.Round(newWidth / aspectRatio);
        }
        else if (aspectRatio > 1 && originalImage.Height > maxHeight)
        {
            newHeight = maxHeight;
            newWidth = (int)Math.Round(newHeight * aspectRatio);
        }

        return new Bitmap(originalImage, newWidth, newHeight);
    }

    private Bitmap ResizeImageConstant(Stream streamImage, int width, int height)
    {
        Bitmap originalImage = new Bitmap(streamImage);
        return new Bitmap(originalImage, width, height);
    }
}