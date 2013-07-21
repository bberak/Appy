﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Appy.Core;

namespace Appy.ExampleApp
{
    public class ExceptionController : Controller
    {
        [Url("/throw-exception")]
        public Response ThrowException(Request incoming)
        {
            string type = incoming.QueryString.Find("type");

            if (type.Equals("FieldAccessException"))
                throw new FieldAccessException("Oops, an error occurred");
            else
                throw new Exception("Oops, another error occurred!");
        }

        [Catches]
        public void HandleException(Exception ex)
        {
            MessageBox.Show(string.Format("Exception occurred:\n\n{0}", ex.ToString()),
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        [Catches(typeof(FieldAccessException))]
        public Response HandleFieldException(Exception ex)
        {
            return new BasicResponse(ex).With(r => r.StatusCode = 500);
        }

        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();

            MessageBox.Show("Disposing Exception controller!");
        }
    }
}
