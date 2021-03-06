﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS.Features.Configuration
{
    /// <summary>
    /// The FeatureToggleSettings Configuration Section.
    /// </summary>
    public partial class FeatureToggleSettings : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the FeatureToggleSettings Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string FeatureToggleSettingsSectionName = "featureToggles";
        
        /// <summary>
        /// Gets the FeatureToggleSettings instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::MS.Features.Configuration.FeatureToggleSettings Instance
        {
            get
            {
                return ((global::MS.Features.Configuration.FeatureToggleSettings)(global::System.Configuration.ConfigurationManager.GetSection(global::MS.Features.Configuration.FeatureToggleSettings.FeatureToggleSettingsSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::MS.Features.Configuration.FeatureToggleSettings.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::MS.Features.Configuration.FeatureToggleSettings.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Features Property
        /// <summary>
        /// The XML name of the <see cref="Features"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string FeaturesPropertyName = "features";
        
        /// <summary>
        /// Gets or sets the Features.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Features.")]
        [global::System.ComponentModel.DisplayNameAttribute("Toggles")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::MS.Features.Configuration.FeatureToggleSettings.FeaturesPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=true)]
        public virtual global::MS.Features.Configuration.FeatureToggleCollection Features
        {
            get
            {
                return ((global::MS.Features.Configuration.FeatureToggleCollection)(base[global::MS.Features.Configuration.FeatureToggleSettings.FeaturesPropertyName]));
            }
            set
            {
                base[global::MS.Features.Configuration.FeatureToggleSettings.FeaturesPropertyName] = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// A collection of FeatureToggleElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::MS.Features.Configuration.FeatureToggleElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::MS.Features.Configuration.FeatureToggleCollection.FeatureToggleElementPropertyName)]
    public partial class FeatureToggleCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string FeatureToggleElementPropertyName = "feature";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override string ElementName
        {
            get
            {
                return global::MS.Features.Configuration.FeatureToggleCollection.FeatureToggleElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::MS.Features.Configuration.FeatureToggleCollection.FeatureToggleElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::MS.Features.Configuration.FeatureToggleElement)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::MS.Features.Configuration.FeatureToggleElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::MS.Features.Configuration.FeatureToggleElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::MS.Features.Configuration.FeatureToggleElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::MS.Features.Configuration.FeatureToggleElement this[int index]
        {
            get
            {
                return ((global::MS.Features.Configuration.FeatureToggleElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::MS.Features.Configuration.FeatureToggleElement this[object name]
        {
            get
            {
                return ((global::MS.Features.Configuration.FeatureToggleElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="feature">The <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Add(global::MS.Features.Configuration.FeatureToggleElement feature)
        {
            base.BaseAdd(feature);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="feature">The <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Remove(global::MS.Features.Configuration.FeatureToggleElement feature)
        {
            base.BaseRemove(this.GetElementKey(feature));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::MS.Features.Configuration.FeatureToggleElement GetItemAt(int index)
        {
            return ((global::MS.Features.Configuration.FeatureToggleElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::MS.Features.Configuration.FeatureToggleElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::MS.Features.Configuration.FeatureToggleElement GetItemByKey(string name)
        {
            return ((global::MS.Features.Configuration.FeatureToggleElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }

    /// <summary>
    /// The FeatureToggleElement Configuration Element.
    /// </summary>
    public partial class FeatureToggleElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::MS.Features.Configuration.FeatureToggleElement.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::MS.Features.Configuration.FeatureToggleElement.NamePropertyName]));
            }
            set
            {
                base[global::MS.Features.Configuration.FeatureToggleElement.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Enabled Property
        /// <summary>
        /// The XML name of the <see cref="Enabled"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EnabledPropertyName = "enabled";
        
        /// <summary>
        /// Gets or sets the Enabled.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Enabled.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::MS.Features.Configuration.FeatureToggleElement.EnabledPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual bool Enabled
        {
            get
            {
                return ((bool)(base[global::MS.Features.Configuration.FeatureToggleElement.EnabledPropertyName]));
            }
            set
            {
                base[global::MS.Features.Configuration.FeatureToggleElement.EnabledPropertyName] = value;
            }
        }
        #endregion
    }
}