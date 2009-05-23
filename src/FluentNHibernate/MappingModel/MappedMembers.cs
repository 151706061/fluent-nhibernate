﻿using System;
using System.Collections.Generic;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.MappingModel
{
    internal class MappedMembers : IMappingBase, IHasMappedMembers
    {
        private readonly IList<PropertyMapping> properties;
        private readonly IList<ICollectionMapping> collections;
        private readonly IList<ManyToOneMapping> references;
        private readonly IList<ComponentMappingBase> components;
        private readonly IList<VersionMapping> versions;

        public MappedMembers()
        {
            properties = new List<PropertyMapping>();
            collections = new List<ICollectionMapping>();
            references = new List<ManyToOneMapping>();    
            components = new List<ComponentMappingBase>();
            versions = new List<VersionMapping>();
        }

        public IEnumerable<PropertyMapping> Properties
        {
            get { return properties; }
        }

        public IEnumerable<ICollectionMapping> Collections
        {
            get { return collections; }
        }

        public IEnumerable<ManyToOneMapping> References
        {
            get { return references; }
        }

        public IEnumerable<ComponentMappingBase> Components
        {
            get { return components; }
        }

        public IList<VersionMapping> Versions
        {
            get { return versions; }
        }

        public void AddProperty(PropertyMapping property)
        {
            properties.Add(property);
        }

        public void AddVersion(VersionMapping version)
        {
            versions.Add(version);
        }

        public void AddCollection(ICollectionMapping collection)
        {
            collections.Add(collection);
        }

        public void AddReference(ManyToOneMapping manyToOne)
        {
            references.Add(manyToOne);
        }

        public void AddComponent(ComponentMappingBase componentMapping)
        {
            components.Add(componentMapping);
        }

        public virtual void AcceptVisitor(IMappingModelVisitor visitor)
        {
            foreach (var collection in Collections)
                visitor.Visit(collection);

            foreach (var property in Properties)
                visitor.Visit(property);

            foreach (var reference in References)
                visitor.Visit(reference);

            foreach (var component in Components)
                visitor.Visit(component);

            foreach (var version in versions)
                visitor.Visit(version);
        }
    }
}
