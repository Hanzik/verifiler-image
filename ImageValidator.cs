using System;
using System.Drawing;
using NLog;
using VerifilerCore;

namespace VerifilerImage {
	/// <summary>
	/// This validation step tries to load the image file via built-in Bitmap class.
	/// 
	/// The error code produced by this validation is Error.Corrupted.
	/// </summary>
	public class ImageValidator : FormatSpecificValidator {

		public override int ErrorCode { get; set; } = Error.Corrupted;

		public override void Setup() {
			Name = "Image .jpg, .png files verification";
			RelevantExtensions.Add(".jpg");
			RelevantExtensions.Add(".png");
			Enable();
		}

		public override void ValidateFile(string file) {
			try {
				Bitmap image = new Bitmap(file);
			} catch (Exception e) {
				ReportAsError("File is corrupted: " + file + "; Message: " + e.Message);
			}
		}
	}
}