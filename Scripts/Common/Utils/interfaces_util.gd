class_name InterfacesUtil


static func implements_interface(obj, method_list: Array) -> void:
	for method_name in method_list:
		assert(obj.has_method(method_name))
