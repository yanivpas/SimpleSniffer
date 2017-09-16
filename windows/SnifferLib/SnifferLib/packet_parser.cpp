#include "stdafx.h"
#include <string.h>
#include "tcpip.h"
#include "packet_parser.h"


enum pparser_error get_tcp_data(char *packet, 
                                size_t packet_len, 
                                struct connection *conn,
                                char *tcp_flags, char **data)
{
    struct ethernet_header *eth = (struct ethernet_header*)packet;
    struct ipv4_header *ip = NULL;
    struct tcp_header *tcp = NULL;
    enum pparser_error ret_value = PPARSER_NOT_TCP_PACKET;

    /* Layer 2 check */
    if ((packet_len < sizeof(*eth)) |
        (ntohs(eth->type) != ETHERNET_TYPE_IPV4)) {
		ret_value = PPARSER_ERROR_L2;
        goto exit;
    }
    packet_len -= sizeof(*eth);
    packet += sizeof(*eth);

    /* Layer 3 check */
    ip = (struct ipv4_header*)(packet);
    if ((packet_len < sizeof(*ip)) |
        (ip->protocol != IP_PROTOCOL_TCP)) {
		ret_value = PPARSER_ERROR_L3;
        goto exit;
    }

    packet_len -= ip->header_len*sizeof(uint32_t);
    packet += ip->header_len*sizeof(uint32_t);

    /* Layer 4 check */
    tcp = (struct tcp_header*)packet;
    if (packet_len < (tcp->header_len/4)) {
		ret_value = PPARSER_ERROR_L4;
        goto exit;
    }

    /* set the tcp_flags */
    if (NULL != tcp_flags) {
        *tcp_flags = tcp->flags;
    }

    /* set the connection */
    if (NULL != conn) {
        memcpy(conn->src, ip->src, IPV4_ADDRESS_SIZE);
        memcpy(conn->dst, ip->dst, IPV4_ADDRESS_SIZE);
        conn->src_port = ntohs(tcp->src_port);
        conn->dst_port = ntohs(tcp->dst_port);
    }
   
    /* find the data location */
    packet += (tcp->header_len/sizeof(uint32_t));
    packet_len -= (tcp->header_len/sizeof(uint32_t));
    if (packet_len > 0) {
        *data = packet;
    } else {
        *data = NULL;
    }
        
    ret_value = SUCCESS;
    

exit:
    return ret_value;
}
