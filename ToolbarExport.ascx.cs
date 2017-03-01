// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarExport.ascx.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The demo export format.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;

    using DevExpress.Web;

    #endregion

    /// <summary>
    /// The demo export format.
    /// </summary>
    public enum DemoExportFormat
    {
        /// <summary>
        /// The pdf.
        /// </summary>
        Pdf,

        /// <summary>
        /// The xls.
        /// </summary>
        Xls,

        /// <summary>
        /// The xlsx.
        /// </summary>
        Xlsx,

        /// <summary>
        /// The rtf.
        /// </summary>
        Rtf,

        /// <summary>
        /// The csv.
        /// </summary>
        Csv
    }

    /// <summary>
    /// The toolbar export.
    /// </summary>
    public partial class ToolbarExport : UserControl
    {
        /// <summary>
        /// The event item click.
        /// </summary>
        private static readonly object EventItemClick = new object();

        /// <summary>
        /// The export item types.
        /// </summary>
        private DemoExportFormat[] exportItemTypes;

        /// <summary>
        /// The item icons.
        /// </summary>
        private Dictionary<DemoExportFormat, string> itemIcons;

        /// <summary>
        /// The export item click event handler.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExportItemClickEventHandler(object source, ExportItemClickEventArgs e);

        /// <summary>
        /// The item click.
        /// </summary>
        public event ExportItemClickEventHandler ItemClick
        {
            add
            {
                this.Events.AddHandler(EventItemClick, value);
            }

            remove
            {
                this.Events.RemoveHandler(EventItemClick, value);
            }
        }

        /// <summary>
        /// Gets or sets the export item types.
        /// </summary>
        [TypeConverter(typeof(EnumConverter))]
        public DemoExportFormat[] ExportItemTypes
        {
            get
            {
                if (this.exportItemTypes == null)
                {
                    this.exportItemTypes = Enum.GetValues(typeof(DemoExportFormat)).Cast<DemoExportFormat>().ToArray();
                }

                return this.exportItemTypes;
            }

            set
            {
                this.exportItemTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is data aware xls.
        /// </summary>
        public bool IsDataAwareXls { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is data aware xlsx.
        /// </summary>
        public bool IsDataAwareXlsx { get; set; }

        /// <summary>
        /// Gets the item icons.
        /// </summary>
        protected Dictionary<DemoExportFormat, string> ItemIcons
        {
            get
            {
                if (this.itemIcons == null)
                {
                    this.itemIcons = new Dictionary<DemoExportFormat, string>();
                    this.FillItemIcons();
                }

                return this.itemIcons;
            }
        }

        /// <summary>
        /// The menu export buttons_ item click.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void MenuExportButtonsItemClick(object source, MenuItemEventArgs e)
        {
            var handler = (ExportItemClickEventHandler)this.Events[EventItemClick];
            handler?.Invoke(
                this,
                new ExportItemClickEventArgs((DemoExportFormat)Enum.Parse(typeof(DemoExportFormat), e.Item.Name)));
        }

        /// <summary>
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            foreach (var type in this.ExportItemTypes)
            {
                this.CreateMenuItem(type);
            }
        }

        /// <summary>
        /// The create menu item.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        protected void CreateMenuItem(DemoExportFormat type)
        {
            var item = new MenuItem(string.Empty, type.ToString());
            this.MenuExportButtons.Items.Add(item);
            if (this.ItemIcons.ContainsKey(type))
            {
                item.Image.IconID = this.ItemIcons[type];
            }

            item.ToolTip = this.GetItemToolTip(type);
        }

        /// <summary>
        /// The fill item icons.
        /// </summary>
        protected void FillItemIcons()
        {
            this.ItemIcons[DemoExportFormat.Pdf] = "export_exporttopdf_32x32";
            this.ItemIcons[DemoExportFormat.Xls] = "export_exporttoxls_32x32";
            this.ItemIcons[DemoExportFormat.Xlsx] = "export_exporttoxlsx_32x32";
            this.ItemIcons[DemoExportFormat.Rtf] = "export_exporttortf_32x32";
            this.ItemIcons[DemoExportFormat.Csv] = "export_exporttocsv_32x32";
        }

        /// <summary>
        /// The get item tool tip.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetItemToolTip(DemoExportFormat type)
        {
            var result = "Export to " + type.ToString();
            if ((this.IsDataAwareXls && (type == DemoExportFormat.Xls))
                || (this.IsDataAwareXlsx && (type == DemoExportFormat.Xlsx)))
            {
                result += " (DataAware)";
            }

            return result;
        }
    }

    /// <summary>
    /// The item tooltips.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class ItemTooltips : Collection<ItemTooltip>
    {
    }

    /// <summary>
    /// The item tooltip.
    /// </summary>
    public class ItemTooltip : CollectionItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemTooltip"/> class.
        /// </summary>
        public ItemTooltip()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemTooltip"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="toolTip">
        /// The tool tip.
        /// </param>
        public ItemTooltip(DemoExportFormat type, string toolTip)
        {
            this.Type = type;
            this.ToolTip = toolTip;
        }

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public DemoExportFormat Type { get; set; }
    }

    /// <summary>
    /// The export item click event args.
    /// </summary>
    public class ExportItemClickEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportItemClickEventArgs"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        public ExportItemClickEventArgs(DemoExportFormat type)
        {
            this.ExportType = type;
        }

        /// <summary>
        /// Gets or sets the export type.
        /// </summary>
        public DemoExportFormat ExportType { get; set; }
    }

    /// <summary>
    /// The enum converter.
    /// </summary>
    public class EnumConverter : StringToObjectTypeConverter
    {
        /// <summary>
        /// The convert from.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var items = value.ToString().Split(',');
            var result = new DemoExportFormat[items.Length];
            for (var i = 0; i < items.Length; ++i)
            {
                Enum.TryParse(items[i], out result[i]);
            }

            return result;
        }
    }
}