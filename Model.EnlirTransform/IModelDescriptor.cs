using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    /// <summary>
    /// An interface which provides a basic way of tagging each model item with a numeric id and some 
    /// human readable way of distinguishing between one model and another.
    /// 
    /// The intended use is for api callers to get a list of descriptors for any type of model in which they 
    /// are interested so they decide which they cared about (using the description), and then have easy access 
    /// to get data about that model (using the id)
    /// </summary>
    public interface IModelDescriptor
    {
        /// <summary>
        /// A generated int id for each model. This is useful because most of the rows from the Enlir 
        /// spreadsheet have a string natural key (or none at all), and those strings are not always
        /// HTML Friendly for calling in a rest Api
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Whatever string content/title best would help a human decide in which model instances they have interest. Although 
        /// some models will have properties using the name Description, this field does not always have to map to those properties.
        /// </summary>
        string Description { get; set; }
    }
}
