using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class LegendSphereTransformer : RowTransformerBase<LegendSphereRow, LegendSphere>
    {
        #region Class Variables

        private readonly IntConverter _intConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion

        #region Constructors
        public LegendSphereTransformer(ILogger<RowTransformerBase<LegendSphereRow, LegendSphere>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _realmConverter = new TypeListConverter(new RealmList());
            _intConverter = new IntConverter();
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override LegendSphere ConvertRowToModel(int generatedId, LegendSphereRow row)
        {
            LegendSphere model = new LegendSphere();

            model.Id = generatedId;
            model.Description = $"{row.Character} - {row.BenefitColumn1}";


            model.CharacterName = row.Character;
            model.CharacterId = 0; //filled in during merge phase
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);

            model.Tier = 0; //filled in during merge


            model.LegendSphereInfos = GetLegendSphereInfo(row);

            _logger.LogDebug("Converted LegendSphereRow to LegendSphere: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
        #endregion

        #region Private Methods
        private IEnumerable<LegendSphereInfo> GetLegendSphereInfo(LegendSphereRow row)
        {
            IList<LegendSphereInfo> legendSphereInfos = new List<LegendSphereInfo>();

            //can be up to 4 indexes (spots from left to right)

            //index 1
            if (!String.IsNullOrWhiteSpace(row.BenefitColumn1?.Replace(DashCharacter, String.Empty)))
            {
                LegendSphereInfo lsi1 = new LegendSphereInfo() { Index = 1, Benefit = row.BenefitColumn1, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountColumn1),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };
                    if (iwcasl.ItemCount > 0)
                    {
                        lsi1.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountColumn1),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi1.RequiredMotes.Add(iwcasl);
                    }
                }

                legendSphereInfos.Add(lsi1);

            }

            //index 2
            if (!String.IsNullOrWhiteSpace(row.BenefitColumn2?.Replace(DashCharacter, String.Empty)))
            {
                LegendSphereInfo lsi2 = new LegendSphereInfo() { Index = 2, Benefit = row.BenefitColumn2, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountColumn2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi2.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountColumn2),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi2.RequiredMotes.Add(iwcasl);
                    }
                }

                legendSphereInfos.Add(lsi2);

            }

            //index 3
            if (!String.IsNullOrWhiteSpace(row.BenefitColumn3?.Replace(DashCharacter, String.Empty)))
            {
                LegendSphereInfo lsi3 = new LegendSphereInfo() { Index = 3, Benefit = row.BenefitColumn3, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountColumn3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi3.RequiredMotes.Add(iwcasl);
                    }
                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountColumn3),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi3.RequiredMotes.Add(iwcasl);
                    }
                }               

                legendSphereInfos.Add(lsi3);

            }

            //index 4
            if (!String.IsNullOrWhiteSpace(row.BenefitColumn4?.Replace(DashCharacter, String.Empty)))
            {
                LegendSphereInfo lsi4 = new LegendSphereInfo() { Index = 4, Benefit = row.BenefitColumn4, RequiredMotes = new List<ItemWithCountAndStarLevel>() };

                //mote 1
                if (!String.IsNullOrWhiteSpace(row.Mote1Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote1Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote1AmountColumn4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi4.RequiredMotes.Add(iwcasl);
                    }

                }

                //mote 2
                if (!String.IsNullOrWhiteSpace(row.Mote2Type)) //we use this type of mote
                {
                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(row.Mote2Type);
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel()
                    {
                        ItemCount = _intConverter.ConvertFromStringToInt(row.Mote2AmountColumn4),
                        ItemName = iwsl.ItemName,
                        ItemStarLevel = iwsl.ItemStarLevel
                    };

                    if (iwcasl.ItemCount > 0)
                    {
                        lsi4.RequiredMotes.Add(iwcasl);
                    }
                }              

                legendSphereInfos.Add(lsi4);
            }

            return legendSphereInfos;
        }

        #endregion
    }
}
