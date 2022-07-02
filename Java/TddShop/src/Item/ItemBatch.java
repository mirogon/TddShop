package Item;

public class ItemBatch {
    private Item item;
    private int stock;
    public ItemBatch(Item i, int stock){
        this.item = i;
        this.stock = stock;
    }
    public Item Item(){
        return item;
    }
    public int Stock(){
        return stock;
    }
}
