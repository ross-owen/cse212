public class FeatureCollection
{
    public string Type { get; set; }
    public FeatureMetadata Metadata { get; set; }
    public List<Feature> Features { get; set; }
    public double[] BBox { get; set; }
}

public class FeatureMetadata
{
    public long Generated {get;set;}
    public string Url {get;set;}
    public string Title {get;set;}
    public int Status {get;set;}
    public string Api {get;set;}
    public int Count {get;set;}
}

public class Feature
{
    public string Type { get; set; }
    public FeatureData Properties { get; set; }
    public FeatureGeometry Geometry { get; set; }
    public string Id { get; set; }
}

public class FeatureData
{
    public double Mag {get;set;}
    public string Place {get;set;}
    public long? Time {get;set;}
    public long? Updated {get;set;}
    public string Tz {get;set;}
    public string Url {get;set;}
    public string Detail {get;set;}
    public double? Felt {get;set;}
    public double? Cdi {get;set;}
    public double? Mmi {get;set;}
    public string Alert {get;set;}
    public string Status {get;set;}
    public long? Tsunami {get;set;}
    public long? Sig {get;set;}
    public string Net {get;set;}
    public string Code {get;set;}
    public string Ids {get;set;}
    public string Sources {get;set;}
    public string Types {get;set;}
    public long? Nst {get;set;}
    public double? Dmin {get;set;}
    public double? Rms {get;set;}
    public double? Gap {get;set;}
    public string MagType {get;set;}
    public string Type {get;set;}
    public string Title {get;set;}    
}

public class FeatureGeometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}
