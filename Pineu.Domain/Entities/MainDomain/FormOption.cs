namespace Pineu.Domain.Entities.MainDomain;
public class FormOption : Entity<Guid> {
    public string Label { get; private set; }
    public Guid? ImageId { get; private set; }

    public Guid FormItemId { get; private set; }
    public FormItem FormItem { get; private set; }
    private FormOption(Guid id) : base(id) { }
    private FormOption(Guid id, string label, Guid formItemId, Guid? imageId) : this(id) {
        Label = label;
        ImageId = imageId;
        FormItemId = formItemId;
    }
    public static FormOption Create(Guid id, string label, Guid formItemId, Guid? imageId) =>
        new(id, label, formItemId, imageId);
    public void Update(string label, Guid formItemId, Guid? imageId) {
        Label = label;
        ImageId = imageId;
        FormItemId = formItemId;
    }
}
