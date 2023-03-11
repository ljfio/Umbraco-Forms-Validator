// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace Our.Umbraco.Forms.Validator.Schema;

[TableName("FormValidationSetting")]
[PrimaryKey(nameof(Id), AutoIncrement = true)]
[ExplicitColumns]
public sealed class FormValidationSettingSchema
{
    [PrimaryKeyColumn(AutoIncrement = true)]
    [Column(nameof(Id))]
    public Guid Id { get; set; }
    
    [Column(nameof(FormId))]
    public Guid FormId { get; set; }
    
    [Column(nameof(RuleId))]
    public Guid RuleId { get; set; }

    [Column(nameof(Message))]
    public string? Message { get; set; }

    [Column(nameof(StopProcessing))]
    public bool StopProcessing { get; set; }
    
    [Column(nameof(Properties))]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public string? Properties { get; set; }

    [VersionColumn(nameof(RowVersion), VersionColumnType.RowVersion)]
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}