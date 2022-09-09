package concretes;



public class Node {
	// Ýkili arama aðacýnýn yapýsýný kullanabilmek düðüm classý
	// Oluþturulacak her düðüm tam sayý olmalýdýr. Oluþturulan çoðu düðümün üst ve alt düðümlerle baðlantýsý olabilir.
	int element;                  //Düðümün deðeri
	Node parent;				  //Düðümün atasý
	Node leftChild;               //Düðümün sol çoçuðu
	Node rightChild;              //Düðümün sað çoçuðu
	
	// Yukarýda tanýmlanan özellikler için Getter ve Setter methodlarý
	public int getElement(){
		return this.element; 
	}
	
	public void setElement(int element) {
		this.element = element ;
	}
	
	public Node getParent() {
		return this.parent;
	}
	
	public void setParent(Node parent) { 
		this.parent = parent;
	}
	
	public Node getLeftChild() { 
		return this.leftChild;
	}
	
	public void setLeftChild(Node leftChild) {
		this.leftChild = leftChild; 
	}
	
	public Node getRightChild() { 
		return this.rightChild; 
	}
	
	public void setRightChild(Node rightChild) {
		this.rightChild = rightChild; 
	}
	
	
	// Düðüm sýnýfý için yapýcý blok (constructor)
	public Node(int element, Node parent, Node leftChild, Node rightChild) {
		this.element = element;
		this.parent = parent;
		this.leftChild = leftChild;
		this.rightChild = rightChild;
	}
}
