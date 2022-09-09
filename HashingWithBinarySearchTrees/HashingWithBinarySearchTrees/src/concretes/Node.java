package concretes;



public class Node {
	// �kili arama a�ac�n�n yap�s�n� kullanabilmek d���m class�
	// Olu�turulacak her d���m tam say� olmal�d�r. Olu�turulan �o�u d���m�n �st ve alt d���mlerle ba�lant�s� olabilir.
	int element;                  //D���m�n de�eri
	Node parent;				  //D���m�n atas�
	Node leftChild;               //D���m�n sol �o�u�u
	Node rightChild;              //D���m�n sa� �o�u�u
	
	// Yukar�da tan�mlanan �zellikler i�in Getter ve Setter methodlar�
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
	
	
	// D���m s�n�f� i�in yap�c� blok (constructor)
	public Node(int element, Node parent, Node leftChild, Node rightChild) {
		this.element = element;
		this.parent = parent;
		this.leftChild = leftChild;
		this.rightChild = rightChild;
	}
}
