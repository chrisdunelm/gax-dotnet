/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/quota.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/quota.proto</summary>
  public static partial class QuotaReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/quota.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static QuotaReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZnb29nbGUvYXBpL3F1b3RhLnByb3RvEgpnb29nbGUuYXBpGhxnb29nbGUv",
            "YXBpL2Fubm90YXRpb25zLnByb3RvIl0KBVF1b3RhEiYKBmxpbWl0cxgDIAMo",
            "CzIWLmdvb2dsZS5hcGkuUXVvdGFMaW1pdBIsCgxtZXRyaWNfcnVsZXMYBCAD",
            "KAsyFi5nb29nbGUuYXBpLk1ldHJpY1J1bGUikQEKCk1ldHJpY1J1bGUSEAoI",
            "c2VsZWN0b3IYASABKAkSPQoMbWV0cmljX2Nvc3RzGAIgAygLMicuZ29vZ2xl",
            "LmFwaS5NZXRyaWNSdWxlLk1ldHJpY0Nvc3RzRW50cnkaMgoQTWV0cmljQ29z",
            "dHNFbnRyeRILCgNrZXkYASABKAkSDQoFdmFsdWUYAiABKAM6AjgBIpUCCgpR",
            "dW90YUxpbWl0EgwKBG5hbWUYBiABKAkSEwoLZGVzY3JpcHRpb24YAiABKAkS",
            "FQoNZGVmYXVsdF9saW1pdBgDIAEoAxIRCgltYXhfbGltaXQYBCABKAMSEQoJ",
            "ZnJlZV90aWVyGAcgASgDEhAKCGR1cmF0aW9uGAUgASgJEg4KBm1ldHJpYxgI",
            "IAEoCRIMCgR1bml0GAkgASgJEjIKBnZhbHVlcxgKIAMoCzIiLmdvb2dsZS5h",
            "cGkuUXVvdGFMaW1pdC5WYWx1ZXNFbnRyeRIUCgxkaXNwbGF5X25hbWUYDCAB",
            "KAkaLQoLVmFsdWVzRW50cnkSCwoDa2V5GAEgASgJEg0KBXZhbHVlGAIgASgD",
            "OgI4AUJsCg5jb20uZ29vZ2xlLmFwaUIKUXVvdGFQcm90b1ABWkVnb29nbGUu",
            "Z29sYW5nLm9yZy9nZW5wcm90by9nb29nbGVhcGlzL2FwaS9zZXJ2aWNlY29u",
            "ZmlnO3NlcnZpY2Vjb25maWeiAgRHQVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Quota), global::Google.Api.Quota.Parser, new[]{ "Limits", "MetricRules" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.MetricRule), global::Google.Api.MetricRule.Parser, new[]{ "Selector", "MetricCosts" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.QuotaLimit), global::Google.Api.QuotaLimit.Parser, new[]{ "Name", "Description", "DefaultLimit", "MaxLimit", "FreeTier", "Duration", "Metric", "Unit", "Values", "DisplayName" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Quota configuration helps to achieve fairness and budgeting in service
  /// usage.
  ///
  /// The quota configuration works this way:
  /// - The service configuration defines a set of metrics.
  /// - For API calls, the quota.metric_rules maps methods to metrics with
  ///   corresponding costs.
  /// - The quota.limits defines limits on the metrics, which will be used for
  ///   quota checks at runtime.
  ///
  /// An example quota configuration in yaml format:
  ///
  ///    quota:
  ///      limits:
  ///
  ///      - name: apiWriteQpsPerProject
  ///        metric: library.googleapis.com/write_calls
  ///        unit: "1/min/{project}"  # rate limit for consumer projects
  ///        values:
  ///          STANDARD: 10000
  ///
  ///      # The metric rules bind all methods to the read_calls metric,
  ///      # except for the UpdateBook and DeleteBook methods. These two methods
  ///      # are mapped to the write_calls metric, with the UpdateBook method
  ///      # consuming at twice rate as the DeleteBook method.
  ///      metric_rules:
  ///      - selector: "*"
  ///        metric_costs:
  ///          library.googleapis.com/read_calls: 1
  ///      - selector: google.example.library.v1.LibraryService.UpdateBook
  ///        metric_costs:
  ///          library.googleapis.com/write_calls: 2
  ///      - selector: google.example.library.v1.LibraryService.DeleteBook
  ///        metric_costs:
  ///          library.googleapis.com/write_calls: 1
  ///
  ///  Corresponding Metric definition:
  ///
  ///      metrics:
  ///      - name: library.googleapis.com/read_calls
  ///        display_name: Read requests
  ///        metric_kind: DELTA
  ///        value_type: INT64
  ///
  ///      - name: library.googleapis.com/write_calls
  ///        display_name: Write requests
  ///        metric_kind: DELTA
  ///        value_type: INT64
  /// </summary>
  public sealed partial class Quota : pb::IMessage<Quota> {
    private static readonly pb::MessageParser<Quota> _parser = new pb::MessageParser<Quota>(() => new Quota());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Quota> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota(Quota other) : this() {
      limits_ = other.limits_.Clone();
      metricRules_ = other.metricRules_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota Clone() {
      return new Quota(this);
    }

    /// <summary>Field number for the "limits" field.</summary>
    public const int LimitsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Google.Api.QuotaLimit> _repeated_limits_codec
        = pb::FieldCodec.ForMessage(26, global::Google.Api.QuotaLimit.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.QuotaLimit> limits_ = new pbc::RepeatedField<global::Google.Api.QuotaLimit>();
    /// <summary>
    /// List of `QuotaLimit` definitions for the service.
    ///
    /// Used by metric-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.QuotaLimit> Limits {
      get { return limits_; }
    }

    /// <summary>Field number for the "metric_rules" field.</summary>
    public const int MetricRulesFieldNumber = 4;
    private static readonly pb::FieldCodec<global::Google.Api.MetricRule> _repeated_metricRules_codec
        = pb::FieldCodec.ForMessage(34, global::Google.Api.MetricRule.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.MetricRule> metricRules_ = new pbc::RepeatedField<global::Google.Api.MetricRule>();
    /// <summary>
    /// List of `MetricRule` definitions, each one mapping a selected method to one
    /// or more metrics.
    ///
    /// Used by metric-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.MetricRule> MetricRules {
      get { return metricRules_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Quota);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Quota other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!limits_.Equals(other.limits_)) return false;
      if(!metricRules_.Equals(other.metricRules_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= limits_.GetHashCode();
      hash ^= metricRules_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      limits_.WriteTo(output, _repeated_limits_codec);
      metricRules_.WriteTo(output, _repeated_metricRules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += limits_.CalculateSize(_repeated_limits_codec);
      size += metricRules_.CalculateSize(_repeated_metricRules_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Quota other) {
      if (other == null) {
        return;
      }
      limits_.Add(other.limits_);
      metricRules_.Add(other.metricRules_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 26: {
            limits_.AddEntriesFrom(input, _repeated_limits_codec);
            break;
          }
          case 34: {
            metricRules_.AddEntriesFrom(input, _repeated_metricRules_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Bind API methods to metrics. Binding a method to a metric causes that
  /// metric's configured quota, billing, and monitoring behaviors to apply to the
  /// method call.
  ///
  /// Used by metric-based quotas only.
  /// </summary>
  public sealed partial class MetricRule : pb::IMessage<MetricRule> {
    private static readonly pb::MessageParser<MetricRule> _parser = new pb::MessageParser<MetricRule>(() => new MetricRule());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MetricRule> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule(MetricRule other) : this() {
      selector_ = other.selector_;
      metricCosts_ = other.metricCosts_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule Clone() {
      return new MetricRule(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private string selector_ = "";
    /// <summary>
    /// Selects the methods to which this rule applies.
    ///
    /// Refer to [selector][google.api.DocumentationRule.selector] for syntax details.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Selector {
      get { return selector_; }
      set {
        selector_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "metric_costs" field.</summary>
    public const int MetricCostsFieldNumber = 2;
    private static readonly pbc::MapField<string, long>.Codec _map_metricCosts_codec
        = new pbc::MapField<string, long>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForInt64(16), 18);
    private readonly pbc::MapField<string, long> metricCosts_ = new pbc::MapField<string, long>();
    /// <summary>
    /// Metrics to update when the selected methods are called, and the associated
    /// cost applied to each metric.
    ///
    /// The key of the map is the metric name, and the values are the amount
    /// increased for the metric against which the quota limits are defined.
    /// The value must not be negative.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, long> MetricCosts {
      get { return metricCosts_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MetricRule);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MetricRule other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Selector != other.Selector) return false;
      if (!MetricCosts.Equals(other.MetricCosts)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Selector.Length != 0) hash ^= Selector.GetHashCode();
      hash ^= MetricCosts.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      metricCosts_.WriteTo(output, _map_metricCosts_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Selector.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Selector);
      }
      size += metricCosts_.CalculateSize(_map_metricCosts_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MetricRule other) {
      if (other == null) {
        return;
      }
      if (other.Selector.Length != 0) {
        Selector = other.Selector;
      }
      metricCosts_.Add(other.metricCosts_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            metricCosts_.AddEntriesFrom(input, _map_metricCosts_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// `QuotaLimit` defines a specific limit that applies over a specified duration
  /// for a limit type. There can be at most one limit for a duration and limit
  /// type combination defined within a `QuotaGroup`.
  /// </summary>
  public sealed partial class QuotaLimit : pb::IMessage<QuotaLimit> {
    private static readonly pb::MessageParser<QuotaLimit> _parser = new pb::MessageParser<QuotaLimit>(() => new QuotaLimit());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<QuotaLimit> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit(QuotaLimit other) : this() {
      name_ = other.name_;
      description_ = other.description_;
      defaultLimit_ = other.defaultLimit_;
      maxLimit_ = other.maxLimit_;
      freeTier_ = other.freeTier_;
      duration_ = other.duration_;
      metric_ = other.metric_;
      unit_ = other.unit_;
      values_ = other.values_.Clone();
      displayName_ = other.displayName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit Clone() {
      return new QuotaLimit(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 6;
    private string name_ = "";
    /// <summary>
    /// Name of the quota limit. The name is used to refer to the limit when
    /// overriding the default limit on per-consumer basis.
    ///
    /// For group-based quota limits, the name must be unique within the quota
    /// group. If a name is not provided, it will be generated from the limit_by
    /// and duration fields.
    ///
    /// For metric-based quota limits, the name must be provided, and it must be
    /// unique within the service. The name can only include alphanumeric
    /// characters as well as '-'.
    ///
    /// The maximum length of the limit name is 64 characters.
    ///
    /// The name of a limit is used as a unique identifier for this limit.
    /// Therefore, once a limit has been put into use, its name should be
    /// immutable. You can use the display_name field to provide a user-friendly
    /// name for the limit. The display name can be evolved over time without
    /// affecting the identity of the limit.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 2;
    private string description_ = "";
    /// <summary>
    /// Optional. User-visible, extended description for this quota limit.
    /// Should be used only when more context is needed to understand this limit
    /// than provided by the limit's display name (see: `display_name`).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "default_limit" field.</summary>
    public const int DefaultLimitFieldNumber = 3;
    private long defaultLimit_;
    /// <summary>
    /// Default number of tokens that can be consumed during the specified
    /// duration. This is the number of tokens assigned when a client
    /// application developer activates the service for his/her project.
    ///
    /// Specifying a value of 0 will block all requests. This can be used if you
    /// are provisioning quota to selected consumers and blocking others.
    /// Similarly, a value of -1 will indicate an unlimited quota. No other
    /// negative values are allowed.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long DefaultLimit {
      get { return defaultLimit_; }
      set {
        defaultLimit_ = value;
      }
    }

    /// <summary>Field number for the "max_limit" field.</summary>
    public const int MaxLimitFieldNumber = 4;
    private long maxLimit_;
    /// <summary>
    /// Maximum number of tokens that can be consumed during the specified
    /// duration. Client application developers can override the default limit up
    /// to this maximum. If specified, this value cannot be set to a value less
    /// than the default limit. If not specified, it is set to the default limit.
    ///
    /// To allow clients to apply overrides with no upper bound, set this to -1,
    /// indicating unlimited maximum quota.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MaxLimit {
      get { return maxLimit_; }
      set {
        maxLimit_ = value;
      }
    }

    /// <summary>Field number for the "free_tier" field.</summary>
    public const int FreeTierFieldNumber = 7;
    private long freeTier_;
    /// <summary>
    /// Free tier value displayed in the Developers Console for this limit.
    /// The free tier is the number of tokens that will be subtracted from the
    /// billed amount when billing is enabled.
    /// This field can only be set on a limit with duration "1d", in a billable
    /// group; it is invalid on any other limit. If this field is not set, it
    /// defaults to 0, indicating that there is no free tier for this service.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long FreeTier {
      get { return freeTier_; }
      set {
        freeTier_ = value;
      }
    }

    /// <summary>Field number for the "duration" field.</summary>
    public const int DurationFieldNumber = 5;
    private string duration_ = "";
    /// <summary>
    /// Duration of this limit in textual notation. Example: "100s", "24h", "1d".
    /// For duration longer than a day, only multiple of days is supported. We
    /// support only "100s" and "1d" for now. Additional support will be added in
    /// the future. "0" indicates indefinite duration.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Duration {
      get { return duration_; }
      set {
        duration_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "metric" field.</summary>
    public const int MetricFieldNumber = 8;
    private string metric_ = "";
    /// <summary>
    /// The name of the metric this quota limit applies to. The quota limits with
    /// the same metric will be checked together during runtime. The metric must be
    /// defined within the service config.
    ///
    /// Used by metric-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Metric {
      get { return metric_; }
      set {
        metric_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "unit" field.</summary>
    public const int UnitFieldNumber = 9;
    private string unit_ = "";
    /// <summary>
    /// Specify the unit of the quota limit. It uses the same syntax as
    /// [Metric.unit][]. The supported unit kinds are determined by the quota
    /// backend system.
    ///
    /// The [Google Service Control](https://cloud.google.com/service-control)
    /// supports the following unit components:
    /// * One of the time intevals:
    ///   * "/min"  for quota every minute.
    ///   * "/d"  for quota every 24 hours, starting 00:00 US Pacific Time.
    ///   * Otherwise the quota won't be reset by time, such as storage limit.
    /// * One and only one of the granted containers:
    ///   * "/{organization}" quota for an organization.
    ///   * "/{project}" quota for a project.
    ///   * "/{folder}" quota for a folder.
    ///   * "/{resource}" quota for a universal resource.
    /// * Zero or more quota segmentation dimension. Not all combos are valid.
    ///   * "/{region}" quota for every region. Not to be used with time intervals.
    ///   * Otherwise the resources granted on the target is not segmented.
    ///   * "/{zone}" quota for every zone. Not to be used with time intervals.
    ///   * Otherwise the resources granted on the target is not segmented.
    ///   * "/{resource}" quota for a resource associated with a project or org.
    ///
    /// Here are some examples:
    /// * "1/min/{project}" for quota per minute per project.
    /// * "1/min/{user}" for quota per minute per user.
    /// * "1/min/{organization}" for quota per minute per organization.
    ///
    /// Note: the order of unit components is insignificant.
    /// The "1" at the beginning is required to follow the metric unit syntax.
    ///
    /// Used by metric-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Unit {
      get { return unit_; }
      set {
        unit_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 10;
    private static readonly pbc::MapField<string, long>.Codec _map_values_codec
        = new pbc::MapField<string, long>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForInt64(16), 82);
    private readonly pbc::MapField<string, long> values_ = new pbc::MapField<string, long>();
    /// <summary>
    /// Tiered limit values. Also allows for regional or zone overrides for these
    /// values if "/{region}" or "/{zone}" is specified in the unit field.
    ///
    /// Currently supported tiers from low to high:
    /// VERY_LOW, LOW, STANDARD, HIGH, VERY_HIGH
    ///
    /// To apply different limit values for users according to their tiers, specify
    /// the values for the tiers you want to differentiate. For example:
    /// {LOW:100, STANDARD:500, HIGH:1000, VERY_HIGH:5000}
    ///
    /// The limit value for each tier is optional except for the tier STANDARD.
    /// The limit value for an unspecified tier falls to the value of its next
    /// tier towards tier STANDARD. For the above example, the limit value for tier
    /// STANDARD is 500.
    ///
    /// To apply the same limit value for all users, just specify limit value for
    /// tier STANDARD. For example: {STANDARD:500}.
    ///
    /// To apply a regional overide for a tier, add a map entry with key
    /// "&lt;TIER>/&lt;region>", where &lt;region> is a region name. Similarly, for a zone
    /// override, add a map entry with key "&lt;TIER>/{zone}".
    /// Further, a wildcard can be used at the end of a zone name in order to
    /// specify zone level overrides. For example:
    /// LOW: 10, STANDARD: 50, HIGH: 100,
    /// LOW/us-central1: 20, STANDARD/us-central1: 60, HIGH/us-central1: 200,
    /// LOW/us-central1-*: 10, STANDARD/us-central1-*: 20, HIGH/us-central1-*: 80
    ///
    /// The regional overrides tier set for each region must be the same as
    /// the tier set for default limit values. Same rule applies for zone overrides
    /// tier as well.
    ///
    /// Used by metric-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, long> Values {
      get { return values_; }
    }

    /// <summary>Field number for the "display_name" field.</summary>
    public const int DisplayNameFieldNumber = 12;
    private string displayName_ = "";
    /// <summary>
    /// User-visible display name for this limit.
    /// Optional. If not set, the UI will provide a default display name based on
    /// the quota configuration. This field can be used to override the default
    /// display name generated from the configuration.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DisplayName {
      get { return displayName_; }
      set {
        displayName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as QuotaLimit);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(QuotaLimit other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Description != other.Description) return false;
      if (DefaultLimit != other.DefaultLimit) return false;
      if (MaxLimit != other.MaxLimit) return false;
      if (FreeTier != other.FreeTier) return false;
      if (Duration != other.Duration) return false;
      if (Metric != other.Metric) return false;
      if (Unit != other.Unit) return false;
      if (!Values.Equals(other.Values)) return false;
      if (DisplayName != other.DisplayName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (DefaultLimit != 0L) hash ^= DefaultLimit.GetHashCode();
      if (MaxLimit != 0L) hash ^= MaxLimit.GetHashCode();
      if (FreeTier != 0L) hash ^= FreeTier.GetHashCode();
      if (Duration.Length != 0) hash ^= Duration.GetHashCode();
      if (Metric.Length != 0) hash ^= Metric.GetHashCode();
      if (Unit.Length != 0) hash ^= Unit.GetHashCode();
      hash ^= Values.GetHashCode();
      if (DisplayName.Length != 0) hash ^= DisplayName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Description.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Description);
      }
      if (DefaultLimit != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(DefaultLimit);
      }
      if (MaxLimit != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(MaxLimit);
      }
      if (Duration.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Duration);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Name);
      }
      if (FreeTier != 0L) {
        output.WriteRawTag(56);
        output.WriteInt64(FreeTier);
      }
      if (Metric.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Metric);
      }
      if (Unit.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(Unit);
      }
      values_.WriteTo(output, _map_values_codec);
      if (DisplayName.Length != 0) {
        output.WriteRawTag(98);
        output.WriteString(DisplayName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (DefaultLimit != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(DefaultLimit);
      }
      if (MaxLimit != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MaxLimit);
      }
      if (FreeTier != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(FreeTier);
      }
      if (Duration.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Duration);
      }
      if (Metric.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Metric);
      }
      if (Unit.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Unit);
      }
      size += values_.CalculateSize(_map_values_codec);
      if (DisplayName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DisplayName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(QuotaLimit other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.DefaultLimit != 0L) {
        DefaultLimit = other.DefaultLimit;
      }
      if (other.MaxLimit != 0L) {
        MaxLimit = other.MaxLimit;
      }
      if (other.FreeTier != 0L) {
        FreeTier = other.FreeTier;
      }
      if (other.Duration.Length != 0) {
        Duration = other.Duration;
      }
      if (other.Metric.Length != 0) {
        Metric = other.Metric;
      }
      if (other.Unit.Length != 0) {
        Unit = other.Unit;
      }
      values_.Add(other.values_);
      if (other.DisplayName.Length != 0) {
        DisplayName = other.DisplayName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 18: {
            Description = input.ReadString();
            break;
          }
          case 24: {
            DefaultLimit = input.ReadInt64();
            break;
          }
          case 32: {
            MaxLimit = input.ReadInt64();
            break;
          }
          case 42: {
            Duration = input.ReadString();
            break;
          }
          case 50: {
            Name = input.ReadString();
            break;
          }
          case 56: {
            FreeTier = input.ReadInt64();
            break;
          }
          case 66: {
            Metric = input.ReadString();
            break;
          }
          case 74: {
            Unit = input.ReadString();
            break;
          }
          case 82: {
            values_.AddEntriesFrom(input, _map_values_codec);
            break;
          }
          case 98: {
            DisplayName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
