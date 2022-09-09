package concretes;

public class BinarySearchTree {
	
				// Kök düðümü kullanýlarak eklenmek istenilen sayý aðaca bu method sayesinde eklenir
				public void AddNode(Node node, Node root) { 
					
					Node current = root;
			        Node previous = null;
			        
			        // Eklenmek istenilen sayý deðiþkene aktarýlýr
			        int number = node.getElement();

			        // Eklenilecek düðümün deðeri kök düðümün referans alýnmasýyla baþlayýp travrse iþlemiyle eklenmek istenilen deðere göre yer bulunur 
			        while (current != null) {
			            previous = current;
			            if (number <= current.getElement()) {
			                current = current.getLeftChild();
			            }
			            else {
			                current = current.getRightChild();
			            }
			        }
			        
			        // Yeni düðümün sað çocuk mu sol çocuk mu olacaðý tespit edilir
			        if (number <= previous.getElement()) {
			            previous.setLeftChild(node);
			            node.setParent(previous);
			        }
			        else {
			            previous.setRightChild(node);
			            node.setParent(previous);
			        }
			    } 
				
				// Aðaç yapýsýnda bulunan deðerler bu method sayesinde sýrasýyla yazdýrýlýr
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
				
				// Aranan sayýnýn aðaç yapýsýnda bulunan düðüm deðerleri içerisinde olup olmadýðýný bulmak için traverse iþlemi yapýlýr
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
