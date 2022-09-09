package concretes;

public class BinarySearchTree {
	
				// K�k d���m� kullan�larak eklenmek istenilen say� a�aca bu method sayesinde eklenir
				public void AddNode(Node node, Node root) { 
					
					Node current = root;
			        Node previous = null;
			        
			        // Eklenmek istenilen say� de�i�kene aktar�l�r
			        int number = node.getElement();

			        // Eklenilecek d���m�n de�eri k�k d���m�n referans al�nmas�yla ba�lay�p travrse i�lemiyle eklenmek istenilen de�ere g�re yer bulunur 
			        while (current != null) {
			            previous = current;
			            if (number <= current.getElement()) {
			                current = current.getLeftChild();
			            }
			            else {
			                current = current.getRightChild();
			            }
			        }
			        
			        // Yeni d���m�n sa� �ocuk mu sol �ocuk mu olaca�� tespit edilir
			        if (number <= previous.getElement()) {
			            previous.setLeftChild(node);
			            node.setParent(previous);
			        }
			        else {
			            previous.setRightChild(node);
			            node.setParent(previous);
			        }
			    } 
				
				// A�a� yap�s�nda bulunan de�erler bu method sayesinde s�ras�yla yazd�r�l�r
				public void inorderTraversalPrint(Node root) {
					if (root.getLeftChild() != null) {
						inorderTraversalPrint(root.getLeftChild());
					}
					if(root != null) {
						System.out.print(root.getElement() + " ");
					}
					if (root.getRightChild() != null) {
						inorderTraversalPrint(root.getRightChild());
					}	
				} 
				
				// Aranan say�n�n a�a� yap�s�nda bulunan d���m de�erleri i�erisinde olup olmad���n� bulmak i�in traverse i�lemi yap�l�r
				public boolean searchTree(Node root, int number) {
					
					boolean found = false;
			        Node node = root;
			        
			        while(!found && node != null) {
			        	
			            if(number == node.getElement()) {
			                found = true;
			            }
			            else if(number < node.getElement()) {
			                node = node.getLeftChild();
			            }
			            else {
			                node = node.getRightChild();
			            }
			        }
			        return found;
				} 
}
