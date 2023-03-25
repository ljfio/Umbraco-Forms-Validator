// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace Our.Umbraco.Forms.Validator.Infrastructure;

[TableName(TableName)]
[PrimaryKey(nameof(Id), AutoIncrement = true)]
[ExplicitColumns]
public sealed class FormValidationSettingSchema
{
    public const string TableName = "FormValidationSetting";
    
    [PrimaryKeyColumn(AutoIncrement = true)]
    [Column(nameof(Id))]
    public int Id { get; set; }
    
    [Column(nameof(Key))]
    [Index(IndexTypes.Clustered)]
    public Guid Key { get; set; }
    
    [Column(nameof(Type))] 
    public string Type { get; set; }
    
    [Column(nameof(Properties))]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public string Properties { get; set; }

    [VersionColumn(nameof(RowVersion), VersionColumnType.RowVersion)]
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}