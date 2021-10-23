using CsvHelper.Configuration;

namespace Assignment_1
{
    public class CustomerInfoClassMap : ClassMap<CustomerInfo>
    {
        public CustomerInfoClassMap()
        {
            Map(m => m.FirstName).Name("First Name").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.LastName).Name("Last Name").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.StreetNumber).Name("Street Number").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.Street).Name("Street").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.City).Name("City").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.Province).Name("Province").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.PostalCode).Name("Postal Code").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.Country).Name("Country").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.PhoneNumber).Name("Phone Number").Validate(x => !string.IsNullOrEmpty(x.Field));
            Map(m => m.EmailAddress).Name("email Address").Validate(x => !string.IsNullOrEmpty(x.Field));
        }
    }
}
