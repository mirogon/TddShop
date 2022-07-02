package Item;

public class Item {
    private String name;
    private int value;
    public Item(String name, int value){
        this.name = name;
        this.value = value;
    }
    public String Name(){
        return name;
    }
    public int Value(){
        return value;
    }
}
