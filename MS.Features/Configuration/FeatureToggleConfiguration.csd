<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="6709332d-5632-4b02-8992-800c6ed4857f" namespace="MS.Features.Configuration" xmlSchemaNamespace="urn:MS.Features.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSectionGroup name="FeatureToggleConfig">
      <configurationSectionProperties>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/6709332d-5632-4b02-8992-800c6ed4857f/FeatureToggleSettings" />
          </containedConfigurationSection>
        </configurationSectionProperty>
      </configurationSectionProperties>
    </configurationSectionGroup>
    <configurationSection name="FeatureToggleSettings" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="featureToggles">
      <elementProperties>
        <elementProperty name="Features" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="features" isReadOnly="false" displayName="Toggles">
          <type>
            <configurationElementCollectionMoniker name="/6709332d-5632-4b02-8992-800c6ed4857f/FeatureToggleCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="FeatureToggleCollection" xmlItemName="feature" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/6709332d-5632-4b02-8992-800c6ed4857f/FeatureToggleElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="FeatureToggleElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/6709332d-5632-4b02-8992-800c6ed4857f/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Enabled" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="enabled" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/6709332d-5632-4b02-8992-800c6ed4857f/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>