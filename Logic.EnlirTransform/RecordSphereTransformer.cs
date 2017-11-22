using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;


namespace FFRKApi.Logic.EnlirTransform
{
    public class RecordSphereTransformer : RowTransformerBase<RecordSphereRow, RecordSphere>
    {

        #region Class Variables

        private readonly IntConverter _intConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion


        #region Constructors
        public RecordSphereTransformer(ILogger<RowTransformerBase<RecordSphereRow, RecordSphere>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _realmConverter = new TypeListConverter(new RealmList());
            _intConverter = new IntConverter();
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override RecordSphere ConvertRowToModel(int generatedId, RecordSphereRow row)
        {
            RecordSphere model = new RecordSphere();

            model.Id = generatedId;
            model.Description = $"{row.Character} - {row.RecordSphereName}";

            model.RecordSphereName = row.RecordSphereName;

            model.CharacterName = row.Character;
            model.CharacterId = 0; //filled in during merge phase
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);


            model.RecordSpherePrerequisites = row.RecordSpherePrerequisites?.Replace(DashCharacter, String.Empty);

            model.RecordSphereLevels = GetRecordSphereLevels(row);

            _logger.LogInformation("Converted RecordSphereRow to RecordSphere: {Id} - {Description}", model.Id, model.Description);

            return model;
        }

        #endregion

        #region Private Methods
        private IEnumerable<RecordSphereLevel> GetRecordSphereLevels(RecordSphereRow row)
        {
            IList<RecordSphereLevel> recordSphereLevels = new List<RecordSphereLevel>();

            //can be up to 5 levels

            //level 1
            if(!String.IsNullOrWhiteSpace(row.BenefitLevel1?.Replace(DashCharacter, String.Empty)))
            {
                RecordSphereLevel rsl = new RecordSphereLevel(){Level = 1, Benefit = row.BenefitLevel1, RequiredMotes = new List<ItemWithCountAndStarLevel>()};

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                                                       {
                                                            ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountLevel1),
                                                            ItemName = iwsl.ItemName,
                                                            ItemStarLevel = iwsl.ItemStarLevel
                                                       };
                    if (iwcasl.ItemCount > 0)
                    {
                        rsl.RequiredMotes.Add(iwcasl);
                    }                    
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                                                       {
                                                           ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountLevel1),
                                                           ItemName = iwsl.ItemName,
                                                           ItemStarLevel = iwsl.ItemStarLevel
                                                       };

                    if (iwcasl.ItemCount > 0)
                    {
                        rsl.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 3
                if (!String.IsNullOrWhiteSpace(row.Mote3Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote3Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                                                       {
                                                           ItemCount = _intConverter.ConvertFromStringToInt(row.Mote3AmountLevel1),
                                                           ItemName = iwsl.ItemName,
                                                           ItemStarLevel = iwsl.ItemStarLevel
                                                       };

                    if (iwcasl.ItemCount > 0)
                    {
                        rsl.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 4
                if (!String.IsNullOrWhiteSpace(row.Mote4Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote4Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                                                       {
                                                           ItemCount = _intConverter.ConvertFromStringToInt(row.Mote4AmountLevel1),
                                                           ItemName = iwsl.ItemName,
                                                           ItemStarLevel = iwsl.ItemStarLevel
                                                       };

                    if (iwcasl.ItemCount > 0)
                    {
                        rsl.RequiredMotes.Add(iwcasl);
                    }
                }

                recordSphereLevels.Add(rsl);

            }

            //level 2
            if (!String.IsNullOrWhiteSpace(row.BenefitLevel2?.Replace(DashCharacter, String.Empty)))
            {
                RecordSphereLevel rs2 = new RecordSphereLevel() { Level = 2, Benefit = row.BenefitLevel2, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountLevel2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs2.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountLevel2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs2.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 3
                if (!String.IsNullOrWhiteSpace(row.Mote3Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote3Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote3AmountLevel2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs2.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 4
                if (!String.IsNullOrWhiteSpace(row.Mote4Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote4Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote4AmountLevel2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs2.RequiredMotes.Add(iwcasl);
                    }
                }

                recordSphereLevels.Add(rs2);

            }

            //level 3
            if (!String.IsNullOrWhiteSpace(row.BenefitLevel3?.Replace(DashCharacter, String.Empty)))
            {
                RecordSphereLevel rs3 = new RecordSphereLevel() { Level = 3, Benefit = row.BenefitLevel3, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountLevel3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs3.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountLevel3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs3.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 3
                if (!String.IsNullOrWhiteSpace(row.Mote3Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote3Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote3AmountLevel3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs3.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 4
                if (!String.IsNullOrWhiteSpace(row.Mote4Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote4Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote4AmountLevel3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs3.RequiredMotes.Add(iwcasl);
                    }
                }

                recordSphereLevels.Add(rs3);

            }

            //level 4
            if (!String.IsNullOrWhiteSpace(row.BenefitLevel4?.Replace(DashCharacter, String.Empty)))
            {
                RecordSphereLevel rs4 = new RecordSphereLevel() { Level = 4, Benefit = row.BenefitLevel4, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountLevel4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs4.RequiredMotes.Add(iwcasl);
                    }

                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountLevel4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs4.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 3
                if (!String.IsNullOrWhiteSpace(row.Mote3Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote3Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote3AmountLevel4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs4.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 4
                if (!String.IsNullOrWhiteSpace(row.Mote4Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote4Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote4AmountLevel4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs4.RequiredMotes.Add(iwcasl);
                    }
                }

                recordSphereLevels.Add(rs4);

            }

            //level 5
            if (!String.IsNullOrWhiteSpace(row.BenefitLevel5?.Replace(DashCharacter, String.Empty)))
            {
                RecordSphereLevel rs5 = new RecordSphereLevel() { Level = 5, Benefit = row.BenefitLevel5, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountLevel5),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs5.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountLevel5),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs5.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 3
                if (!String.IsNullOrWhiteSpace(row.Mote3Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote3Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote3AmountLevel5),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs5.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 4
                if (!String.IsNullOrWhiteSpace(row.Mote4Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote4Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote4AmountLevel5),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        rs5.RequiredMotes.Add(iwcasl);
                    }
                }

                recordSphereLevels.Add(rs5);

            }

           

            return recordSphereLevels;
        }

        #endregion
    }
}
