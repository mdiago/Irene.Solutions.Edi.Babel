# Irene.Solutions.Edi.Babel
Biblioteca para la gestión de documentos Facturae... Generar una factura electrónica en formato facturae y firmarla sería tan sencillo como:

```C#
          
var facturae = new Facturae.V32.Facturae()
{
    // FileHeader
    FileHeader = new Facturae.V32.FileHeaderType()
    {
        Modality = ModalityType.I,
        InvoiceIssuerType = InvoiceIssuerTypeType.EM,
        Batch = new BatchType()
        {
            BatchIdentifier = "B12959755 21/000123",
            InvoicesCount = 1,
            TotalInvoicesAmount = new AmountType()
            {
                TotalAmount = 605
            },
            TotalOutstandingAmount = new AmountType()
            {
                TotalAmount = 605
            },
            TotalExecutableAmount = new AmountType()
            {
                TotalAmount = 605
            },
            InvoiceCurrencyCode = CurrencyCodeType.EUR
        }
    },
    // Parties
    Parties = new PartiesType()
    {
        SellerParty = new BusinessType()
        {
            TaxIdentification = new TaxIdentificationType()
            {
                PersonTypeCode = PersonTypeCodeType.J,
                ResidenceTypeCode = ResidenceTypeCodeType.R,
                TaxIdentificationNumber = "ESB12959755"
            },
            Party = new LegalEntityType()
            {
                CorporateName = "IRENE SOLUTIONS SL",
                TradeName = "ISOLUTIONS",
                RegistrationData = new RegistrationDataType()
                {
                    RegisterOfCompaniesLocation = "CASTELLÓN",
                    Sheet = "CS-38154",
                    Folio = "134",
                    Volume = "1688"
                },
                Address = new AddressType()
                {
                    Address = "AV CAMINO DE ONDA, 25",
                    PostCode = "12530",
                    Town = "BURRIANA",
                    Province = "CASTELLON",
                    CountryCode = CountryType.ESP
                },
                ContactDetails = new ContactDetailsType()
                {
                    Telephone = "964 67 93 95",
                    WebAddress = "www.irenesolutions.com",
                    ElectronicMail = "info@irenesolutions.com"
                }
            }
        },
        BuyerParty = new BusinessType()
        {
            TaxIdentification = new TaxIdentificationType()
            {
                PersonTypeCode = PersonTypeCodeType.J,
                ResidenceTypeCode = ResidenceTypeCodeType.R,
                TaxIdentificationNumber = "ESP0301400H"
            },
            AdministrativeCentres = new AdministrativeCentreType[3]
            {
                new AdministrativeCentreType()
                {
                    CentreCode = "L01030149",
                    RoleTypeCode = RoleTypeCodeType.Receiver,
                    Address = new AddressType()
                    {
                        Address = "PLAZA DEL AYUNTAMIENTO 1",
                        PostCode = "03002",
                        Town = "ALICANTE",
                        Province = "ALICANTE",
                        CountryCode = CountryType.ESP
                    },
                    CentreDescription = "Oficina Contable"
                },
                new AdministrativeCentreType()
                {
                    CentreCode = "L01030149",
                    RoleTypeCode = RoleTypeCodeType.Payer,
                    Address = new AddressType()
                    {
                        Address = "PLAZA DEL AYUNTAMIENTO 1",
                        PostCode = "03002",
                        Town = "ALICANTE",
                        Province = "ALICANTE",
                        CountryCode = CountryType.ESP
                    },
                    CentreDescription = "Organo Gestor"
                },
                new AdministrativeCentreType()
                {
                    CentreCode = "LA0008605",
                    RoleTypeCode = RoleTypeCodeType.Buyer,
                    Address = new AddressType()
                    {
                        Address = "PLAZA DEL AYUNTAMIENTO 1",
                        PostCode = "03002",
                        Town = "ALICANTE",
                        Province = "ALICANTE",
                        CountryCode = CountryType.ESP
                    },
                    CentreDescription = "Unidad Transferencias"
                }
            },
            Party = new LegalEntityType()
            {
                CorporateName = "Ayuntamiento de ALICANTE",
                TradeName = "Ayuntamiento de ALICANTE",
                RegistrationData = new RegistrationDataType()
                {
                    RegisterOfCompaniesLocation = null,
                    Sheet = null,
                    Folio = null,
                    Volume = null
                },
                Address = new AddressType()
                {
                    Address = "Plaza del Ayuntamiento, 1",
                    PostCode = "03002",
                    Town = "ALICANTE",
                    Province = "ALICANTE",
                    CountryCode = CountryType.ESP
                }
            }
        }
    },
    // Invoices
    Invoices = new Facturae.V32.InvoiceType[1]
    { 
        // Invoice
        new Facturae.V32.InvoiceType()
        {
            InvoiceHeader = new InvoiceHeaderType()
            {
                    InvoiceNumber = "000123",
                    InvoiceSeriesCode = null,
                    InvoiceDocumentType = InvoiceDocumentTypeType.FC,
                    InvoiceClass = InvoiceClassType.OO
            },
            InvoiceIssueData = new InvoiceIssueDataType()
            {
                IssueDate = new DateTime(2021, 5, 4),
                InvoiceCurrencyCode =  CurrencyCodeType.EUR,
                TaxCurrencyCode = CurrencyCodeType.EUR,
                LanguageName = LanguageCodeType.es
            },
            TaxesOutputs = new Facturae.V32.TaxOutputType[1]
            {
                new Facturae.V32.TaxOutputType()
                {
                    TaxTypeCode = TaxTypeCodeType.Item01,
                    TaxRate = 21,
                    TaxableBase = new AmountType()
                    {
                        TotalAmount = 500
                    },
                    TaxAmount  = new AmountType()
                    {
                        TotalAmount = 105
                    }
                }
            },
            InvoiceTotals = new Facturae.V32.InvoiceTotalsType()
            {
                    TotalGrossAmount = 500,
                    TotalGeneralDiscounts = 0,
                    TotalGeneralSurcharges = 0,
                    TotalGrossAmountBeforeTaxes = 500,
                    TotalTaxOutputs = 105,
                    TotalTaxesWithheld = 0,
                    InvoiceTotal = 605,
                    TotalOutstandingAmount = 605,
                    TotalExecutableAmount = 605
            },
            Items = new Facturae.V32.InvoiceLineType[1]
            {
                new Facturae.V32.InvoiceLineType()
                {
                    SequenceNumber = 1,
                    ItemDescription = "SOFTWARE DE GESTION DOCUMENTAL IRENEDC 3.0",
                    Quantity = 1,
                    UnitPriceWithoutTax = 500,
                    TotalCost = 500,
                    GrossAmount = 500,
                    TaxesOutputs = new TaxType[1]
                    {
                        new TaxType()
                        {
                            TaxTypeCode = TaxTypeCodeType.Item01,
                            TaxRate = 21,
                            TaxableBase = new AmountType()
                            {
                                TotalAmount = 500
                            },
                            TaxAmount  = new AmountType()
                            {
                                TotalAmount = 105
                            }
                        }
                    }
                }
            },
            // Forma de pago
            PaymentDetails = new InstallmentType[1]
            {
                new InstallmentType()
                {
                    InstallmentDueDate = new DateTime(2021,5,24),
                    InstallmentAmount = 605,
                    PaymentMeans = PaymentMeansType.AcceptedBillOfExchange,
                    AccountToBeCredited = new AccountType()
                    {
                        Account = "ES3721003459832014026539"
                    }
                }
            }
        }
    }


};

// Selecciono el primer certificado
var store = new X509Store();
store.Open(OpenFlags.ReadOnly);
var certificate = store.Certificates[0];

var fe = facturae as Facturae.Facturae;
var feSigned = fe.GetSigned(certificate);

File.WriteAllText(@"C:\Users\usuario\Downloads\test\facturae.signed.sample.xsig", feSigned);


```
