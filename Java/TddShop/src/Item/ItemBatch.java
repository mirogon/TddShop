package Item;

public class ItemBatch {
    private Item item;
    public int Stock;
    public ItemBatch(Item i, int stock){
        this.item = i;
        this.Stock = stock;
    }
    public Item Item(){
        return item;
    }
}
