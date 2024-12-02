using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MockData;

public class MockBlog
{
    private static Dictionary<string, Blog> _blogs = new()
        {
            {"Blog 1", new Blog ("Tur til syrien", DateTime.Now, "John Vestergaard", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras sapien nibh, rutrum sit amet facilisis eleifend, lobortis eu nunc. Suspendisse vestibulum, leo in dapibus eleifend, nibh nisi aliquet lectus, et eleifend nulla lectus eget urna. Aliquam sodales luctus pellentesque. Integer rhoncus orci nec metus dapibus, non auctor risus eleifend. Fusce iaculis nunc non dolor vestibulum fermentum. Duis velit augue, volutpat ut congue nec, tincidunt eu urna. Curabitur rhoncus libero a nisi placerat finibus. Nullam ac orci a quam ultricies aliquet. Maecenas ac ante at nulla fringilla blandit. Duis at congue erat, in faucibus nunc. Nulla facilisi. In luctus elit nec arcu facilisis mollis.\r\n\r\nProin eu fringilla diam, et congue turpis. Proin et semper tellus. Aenean id fringilla felis. Suspendisse sed ipsum euismod, interdum diam et, luctus mi. Mauris eu ultrices lacus, ac vestibulum orci. Aliquam accumsan imperdiet tincidunt. Proin lacus nisi, dapibus eget purus quis, ultricies vehicula lacus. Sed quis massa elit. Maecenas sodales facilisis mi, malesuada mattis massa vehicula eget. Quisque convallis laoreet augue, nec varius massa euismod ac. Etiam interdum felis aliquam mattis rutrum. Suspendisse vitae vulputate tellus. Mauris odio nisi, hendrerit eu rutrum nec, scelerisque ut erat. In vel tortor rutrum, rutrum magna sit amet, pretium risus.") },
            {"Blog 2", new Blog ("Fælles overnatning på himmelbjerget", DateTime.Now, "Yvonne Henriksen", "Aliquam erat volutpat. Nullam vel mattis lorem. Ut egestas nibh eget ultricies efficitur. Proin iaculis faucibus fermentum. Fusce quis magna porta, maximus tellus ultricies, mollis nunc. Integer fermentum auctor felis, et gravida massa sollicitudin ac. Fusce ac felis condimentum, tincidunt tellus eget, dictum risus. Sed viverra velit nec lacus lacinia molestie. Interdum et malesuada fames ac ante ipsum primis in faucibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Pellentesque in tincidunt quam. Maecenas et dui feugiat, gravida lectus nec, gravida nisi. Curabitur tempor massa non molestie congue. Quisque egestas ligula at libero lacinia porta. Nam venenatis massa et fringilla iaculis. In hac habitasse platea dictumst.") }

        };

    public static List<Blog> GetBlogsAsList() => _blogs.Values.ToList();

}


