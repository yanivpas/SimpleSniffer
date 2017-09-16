#include "tcpip.h"

struct connection {
    uint8_t src[IPV4_ADDRESS_SIZE];
    uint8_t dst[IPV4_ADDRESS_SIZE];
    uint16_t src_port;
    uint16_t dst_port;
};

enum pparser_error {
	SUCCESS = 0,
    PPARSER_INTERNAL_ERROR = 5,
    PPARSER_NOT_TCP_PACKET,
	PPARSER_ERROR_L2 = 12,
	PPARSER_ERROR_L3,
	PPARSER_ERROR_L4
};

enum pparser_error get_tcp_data(char *packet, size_t packet_len, struct connection *conn, char *tcp_flags, char **data);
